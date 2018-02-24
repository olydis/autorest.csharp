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

            // we're guaranteed to be in our language-specific context here.
            Settings.Instance.AddCredentials = true;

            // add the Credentials
            // PopulateAdditionalProperties(codeModel);

            // todo: these should be turned into individual transformers
            AzureExtensions.NormalizeAzureClientModel(codeModel);

            // Do parameter transformations
            TransformParameters(codeModel);

            NormalizePaginatedMethods(codeModel);
            NormalizeODataMethods(codeModel);

            foreach (var model in codeModel.ModelTypes)
            {
                if (model.Extensions.ContainsKey(AzureExtensions.AzureResourceExtension) &&
                    (bool)model.Extensions[AzureExtensions.AzureResourceExtension])
                {
                    model.BaseModelType = new CompositeTypeCsa("Microsoft.Rest.Azure.IResource");
                    model.BaseModelType.SerializedName = "Microsoft.Rest.Azure.IResource";
                }
            }

            return codeModel;
        }
    }
}
