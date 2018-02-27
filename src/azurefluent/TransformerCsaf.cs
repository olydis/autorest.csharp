// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System;
using System.Linq;
using AutoRest.Core;
using AutoRest.Core.Model;
using AutoRest.Core.Utilities;
using AutoRest.CSharp.Azure.Fluent.Model;
using AutoRest.CSharp.Azure.Model;
using AutoRest.CSharp.Model;
using AutoRest.Extensions;
using AutoRest.Extensions.Azure;
using static AutoRest.Core.Utilities.DependencyInjection;

namespace AutoRest.CSharp.Azure.Fluent
{
    public class TransformerCsaf : TransformerCsa, ITransformer<CodeModelCsaf>
    {
        CodeModelCsaf ITransformer<CodeModelCsaf>.TransformCodeModel(CodeModel cs)
        {
            var codeModel = cs as CodeModelCsaf;

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

            // Fluent Specific stuff.
            NormalizeResourceTypes(codeModel);
            NormalizeTopLevelTypes(codeModel);
            NormalizeModelProperties(codeModel);


            NormalizePaginatedMethods(codeModel);
            NormalizeODataMethods(codeModel);

            return codeModel;
        }

        /// <summary>
        ///     A type-specific method for code model tranformation.
        ///     Note: This is the method you want to override.
        /// </summary>
        /// <param name="codeModel"></param>
        /// <returns></returns>
        public override CodeModelCs TransformCodeModel(CodeModel codeModel)
        {
            return ((ITransformer<CodeModelCsaf>) this).TransformCodeModel(codeModel);
        }

        public void NormalizeResourceTypes(CodeModelCsaf codeModel)
        {
            if (codeModel != null)
            {
                foreach (var model in codeModel.ModelTypes)
                {
                    if (true == model.BaseModelType?.Extensions?.Get<bool>(AzureExtensions.AzureResourceExtension) && model.Name != "ProxyResource" && model.Name != "TrackedResource")
                    {
                        if (model.BaseModelType.Name == "Resource")
                        {
                            model.BaseModelType = codeModel._resourceType;
                        }
                        else if (model.BaseModelType.Name == "SubResource")
                        {
                            model.BaseModelType = codeModel._subResourceType;
                        }
                    }
                }
            }
        }

        public void NormalizeTopLevelTypes(CodeModelCsaf codeModel)
        {
            foreach (var param in codeModel.Methods.SelectMany(m => m.Parameters))
            {
                AppendInnerToTopLevelType(param.ModelType, codeModel);
            }
            foreach (var response in codeModel.Methods.SelectMany(m => m.Responses).Select(r => r.Value))
            {
                AppendInnerToTopLevelType(response.Body, codeModel);
                AppendInnerToTopLevelType(response.Headers, codeModel);
            }
            foreach (var model in codeModel.ModelTypes)
            {
                if (true == model.BaseModelType?.IsResource())
                {
                    AppendInnerToTopLevelType(model, codeModel);
                }
            }
        }

        private void AppendInnerToTopLevelType(IModelType type, CodeModelCsaf codeModel)
        {
            if ((type is CompositeType compositeType) && !codeModel._innerTypes.Contains(compositeType))
            {
                compositeType.Name.FixedValue = compositeType.Name + "Inner";
                codeModel._innerTypes.Add(compositeType);
            }
            else if (type is SequenceType sequenceType)
            {
                AppendInnerToTopLevelType(sequenceType.ElementType, codeModel);
            }
            else if (type is DictionaryType dictionaryType)
            {
                AppendInnerToTopLevelType(dictionaryType.ValueType, codeModel);
            }
        }

        public void NormalizeModelProperties(CodeModelCsa serviceClient)
        {
            foreach (var modelType in serviceClient.ModelTypes)
            {
                foreach (var property in modelType.Properties)
                {
                    AddNamespaceToResourceType(property.ModelType, serviceClient);
                }
            }
        }

        private void AddNamespaceToResourceType(IModelType type, CodeModelCsa serviceClient)
        {
            // SubResource property { get; set; } => Microsoft.Rest.Azure.SubResource property { get; set; }
            if (type is CompositeType compositeType && compositeType.IsResource() && !compositeType.Name.StartsWith("Microsoft.Rest.Azure."))
            {
                compositeType.Name.FixedValue = "Microsoft.Rest.Azure." + compositeType.Name;
            }
            // iList<SubResource> property { get; set; } => iList<Microsoft.Rest.Azure.SubResource> property { get; set; }
            else if (type is SequenceType sequenceType)
            {
                AddNamespaceToResourceType(sequenceType.ElementType, serviceClient);
            }
            // IDictionary<string, SubResource> property { get; set; } => IDictionary<string, Microsoft.Rest.Azure.SubResource> property { get; set; }
            else if (type is DictionaryType dictionaryType)
            {
                AddNamespaceToResourceType(dictionaryType.ValueType, serviceClient);
            }
        }
    }
}