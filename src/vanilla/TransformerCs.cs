// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using AutoRest.Core;
using AutoRest.Core.Model;
using AutoRest.CSharp.Model;
using AutoRest.Extensions;
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
            SwaggerExtensions.ProcessParameterizedHost(codeModel);

            return codeModel;
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