// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoRest.Core;
using AutoRest.Core.Model;
using AutoRest.Core.Utilities;
using AutoRest.CSharp.Azure.Model;
using AutoRest.CSharp.Model;
using AutoRest.Extensions;
using AutoRest.Extensions.Azure;
using Newtonsoft.Json.Linq;
using static AutoRest.Core.Utilities.DependencyInjection;

namespace AutoRest.CSharp
{
    public class TransformerCs : CodeModelTransformer<CodeModelCs>
    {
        public override CodeModelCs TransformCodeModel(CodeModel cs)
        {
            var codeModel = cs as CodeModelCs;
            // we're guaranteed to be in our language-specific context here.

            // add the Credentials
            PopulateAdditionalProperties(codeModel);

            // todo: these should be turned into individual transformers
            SwaggerExtensions.NormalizeClientModel(codeModel);

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

        protected void NormalizeODataMethods(CodeModel client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            foreach (var method in client.Methods)
            {
                if (method.Extensions.ContainsKey(AzureExtensions.ODataExtension))
                {
                    var odataFilter = method.Parameters.FirstOrDefault(p =>
                        p.SerializedName.EqualsIgnoreCase("$filter") &&
                        (p.Location == ParameterLocation.Query) &&
                        p.ModelType is CompositeType);

                    if (odataFilter == null)
                    {
                        continue;
                    }

                    // Remove all odata parameters
                    method.Remove(source =>
                        (source.SerializedName.EqualsIgnoreCase("$filter") ||
                         source.SerializedName.EqualsIgnoreCase("$top") ||
                         source.SerializedName.EqualsIgnoreCase("$orderby") ||
                         source.SerializedName.EqualsIgnoreCase("$skip") ||
                         source.SerializedName.EqualsIgnoreCase("$expand"))
                        && (source.Location == ParameterLocation.Query));

                    var odataQuery = New<Parameter>(new
                    {
                        SerializedName = "$filter",
                        Name = "odataQuery",
                        ModelType = New<ILiteralType>($"Microsoft.Rest.Azure.OData.ODataQuery<{odataFilter.ModelType.Name}>"),
                        Documentation = "OData parameters to apply to the operation.",
                        Location = ParameterLocation.Query,
                        odataFilter.IsRequired
                    });
                    odataQuery.Extensions[AzureExtensions.ODataExtension] =
                        method.Extensions[AzureExtensions.ODataExtension];
                    method.Insert(odataQuery);
                }
            }
        }

        /// <summary>
        ///     Changes paginated method signatures to return Page type.
        /// </summary>
        /// <param name="codeModel"></param>
        /// <param name="pageClasses"></param>
        protected void NormalizePaginatedMethods(CodeModelCs codeModel)
        {
            if (codeModel == null)
            {
                throw new ArgumentNullException(nameof(codeModel));
            }

            var convertedTypes = new Dictionary<IModelType, CompositeType>();

            foreach (
                var method in
                codeModel.Methods.Where(m => m.Extensions.ContainsKey(AzureExtensions.PageableExtension)))
            {
                string nextLinkString;
                var pageClassName = GetPagingSetting(method.Extensions, codeModel.pageClasses, out nextLinkString);
                if (string.IsNullOrEmpty(pageClassName))
                {
                    continue;
                }
                var pageTypeFormat = "{0}<{1}>";
                var ipageTypeFormat = "Microsoft.Rest.Azure.IPage<{0}>";
                if (string.IsNullOrWhiteSpace(nextLinkString))
                {
                    ipageTypeFormat = "System.Collections.Generic.IEnumerable<{0}>";
                }

                foreach (var responseStatus in method.Responses
                    .Where(r => r.Value.Body is CompositeType).Select(s => s.Key).ToArray())
                {
                    var compositType = (CompositeType)method.Responses[responseStatus].Body;
                    var sequenceType =
                        compositType.Properties.Select(p => p.ModelType).FirstOrDefault(t => t is SequenceType) as
                            SequenceTypeCs;

                    // if the type is a wrapper over page-able response
                    if (sequenceType != null)
                    {
                        var pagableTypeName = string.Format(CultureInfo.InvariantCulture, pageTypeFormat, pageClassName,
                            sequenceType.ElementType.AsNullableType(!sequenceType.ElementType.IsValueType() || sequenceType.IsNullable));
                        var ipagableTypeName = string.Format(CultureInfo.InvariantCulture, ipageTypeFormat,
                            sequenceType.ElementType.AsNullableType(!sequenceType.ElementType.IsValueType() || sequenceType.IsNullable));

                        var pagedResult = New<ILiteralType>(pagableTypeName) as CompositeType;

                        pagedResult.Extensions[AzureExtensions.ExternalExtension] = true;
                        pagedResult.Extensions[AzureExtensions.PageableExtension] = ipagableTypeName;

                        convertedTypes[method.Responses[responseStatus].Body] = pagedResult;
                        method.Responses[responseStatus] = new Response(pagedResult,
                            method.Responses[responseStatus].Headers);
                    }
                }

                if (convertedTypes.ContainsKey(method.ReturnType.Body))
                {
                    method.ReturnType = new Response(convertedTypes[method.ReturnType.Body],
                        method.ReturnType.Headers);
                }
            }

            SwaggerExtensions.RemoveUnreferencedTypes(codeModel,
                new HashSet<string>(convertedTypes.Keys.Cast<CompositeType>().Select(t => t.Name.Value)));
        }

        private static string GetPagingSetting(Dictionary<string, object> extensions,
            IDictionary<KeyValuePair<string, string>, string> pageClasses, out string nextLinkName)
        {
            // default value
            nextLinkName = null;
            var ext = extensions[AzureExtensions.PageableExtension] as JContainer;
            if (ext == null)
            {
                return null;
            }

            nextLinkName = (string)ext["nextLinkName"];
            var itemName = (string)ext["itemName"] ?? "value";

            var keypair = new KeyValuePair<string, string>(nextLinkName, itemName);
            if (!pageClasses.ContainsKey(keypair))
            {
                var className = (string)ext["className"];
                if (string.IsNullOrEmpty(className))
                {
                    if (pageClasses.Count > 0)
                    {
                        className = string.Format(CultureInfo.InvariantCulture, "Page{0}", pageClasses.Count);
                    }
                    else
                    {
                        className = "Page";
                    }
                }
                pageClasses.Add(keypair, className);
            }

            return pageClasses[keypair];
        }

        protected void TransformParameters(CodeModel codeModel)
        {
            // todo: question -- is this just enforcing names?
            foreach (var method in codeModel.Methods)
                foreach (var parameterTransformation in method.InputParameterTransformation)
                {
                    parameterTransformation.OutputParameter.Name =
                        CodeNamer.Instance.GetUnique(
                            CodeNamer.Instance.GetParameterName(parameterTransformation.OutputParameter.GetClientName()),
                            method, method.IdentifiersInScope, method.Children);

                    foreach (var parameterMapping in parameterTransformation.ParameterMappings)
                    {
                        if (parameterMapping.InputParameterProperty != null)
                            parameterMapping.InputParameterProperty =
                                CodeNamer.Instance.GetPropertyName(parameterMapping.InputParameterProperty);

                        if (parameterMapping.OutputParameterProperty != null)
                            parameterMapping.OutputParameterProperty =
                                CodeNamer.Instance.GetPropertyName(parameterMapping.OutputParameterProperty);
                    }
                }
        }

        protected void PopulateAdditionalProperties(CodeModel codeModel)
        {
            if (Settings.Instance.AddCredentials)
                codeModel.Add(New<Property>(new
                {
                    Name = "Credentials",
                    ModelType = New<PrimaryType>(KnownPrimaryType.Credentials),
                    IsRequired = true,
                    IsReadOnly = true,
                    Documentation = "Subscription credentials which uniquely identify client subscription."
                }));
        }
    }
}