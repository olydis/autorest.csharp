// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System;
using System.Collections.Generic;
using System.Globalization;
using AutoRest.Core;
using AutoRest.Core.Model;
using AutoRest.Core.Utilities;
using AutoRest.CSharp.Azure.Model;
using AutoRest.CSharp.Model;
using AutoRest.Extensions;
using AutoRest.Extensions.Azure;
using static AutoRest.Core.Utilities.DependencyInjection;

namespace AutoRest.CSharp.Azure
{
    public class TransformerCsa : TransformerCs, ITransformer<CodeModelCsa>
    {
        /// <summary>
        /// A type-specific method for code model tranformation.
        /// Note: This is the method you want to override.
        /// </summary>
        /// <param name="codeModel"></param>
        /// <returns></returns>
        public override CodeModelCs TransformCodeModel(CodeModel codeModel)
        {
            return ((ITransformer<CodeModelCsa>)this).TransformCodeModel(codeModel);
        }

        CodeModelCsa ITransformer<CodeModelCsa>.TransformCodeModel(CodeModel cs)
        {
            var codeModel = cs as CodeModelCsa;

            // add the Credentials
            // PopulateAdditionalProperties(codeModel);

            var settings = Settings.Instance;
            settings.AddCredentials = true;
            using (NewContext)
            {
                settings = new Settings().LoadFrom(settings);
                settings.AddCredentials = true;

                // This extension from general extensions must be run prior to Azure specific extensions.
                AzureExtensions.ProcessParameterizedHost(codeModel);

                AzureExtensions.ProcessClientRequestIdExtension(codeModel);
                AzureExtensions.UpdateHeadMethods(codeModel);
                AzureExtensions.ParseODataExtension(codeModel);
                AzureExtensions.ProcessGlobalParameters(codeModel);
                AzureExtensions.FlattenModels(codeModel);
                AzureExtensions.FlattenMethodParameters(codeModel);
                ParameterGroupExtensionHelper.AddParameterGroups(codeModel);
                AzureExtensions.AddLongRunningOperations(codeModel);
                AzureExtensions.AddAzureProperties(codeModel);
                AzureExtensions.SetDefaultResponses(codeModel);
                AzureExtensions.AddPageableMethod(codeModel);
            }

            // Do parameter transformations
            TransformParameters(codeModel);

            NormalizePaginatedMethods(codeModel);
            NormalizeODataMethods(codeModel);

            foreach (var model in codeModel.ModelTypes)
            {
                if (true == model.Extensions.Get<bool>(AzureExtensions.AzureResourceExtension))
                {
                    var ires = "Microsoft.Rest.Azure.IResource";
                    model.BaseModelType = new CompositeTypeCsa(ires);
                    model.BaseModelType.Name.FixedValue = ires;
                    model.BaseModelType.SerializedName = ires;
                }
            }

            return codeModel;
        }
    }
}
