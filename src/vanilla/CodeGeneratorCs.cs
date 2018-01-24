// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.Core;
using AutoRest.Core.Model;
using AutoRest.Core.Logging;
using AutoRest.Core.Utilities;
using AutoRest.CSharp.Model;
using AutoRest.CSharp.vanilla.Templates.Rest.Client;
using AutoRest.CSharp.vanilla.Templates.Rest.Common;
using static AutoRest.Core.Utilities.DependencyInjection;
using AutoRest.Extensions;
using Newtonsoft.Json.Linq;
using System.Text;
using AutoRest.CSharp.azure.Templates;

namespace AutoRest.CSharp
{
    public class CodeGeneratorCs : CodeGenerator
    {
        protected const string ClientRuntimePackage = "Microsoft.Rest.ClientRuntime.2.3.8";

        protected virtual string GeneratedSourcesBaseFolder => "";

        protected string FolderModels => Settings.Instance.ModelsName;

        public override string UsageInstructions => string.Format(CultureInfo.InvariantCulture,
            Properties.Resources.UsageInformation, ClientRuntimePackage);

        public override string ImplementationFileExtension => ".cs";

        protected virtual async Task GenerateClientSideCode(CodeModelCs codeModel)
        {
            await GenerateServiceClient(codeModel);
            await GenerateOperations(codeModel);
            await GenerateModels(codeModel.ModelTypes.Union(codeModel.HeaderTypes));
            await GenerateEnums(codeModel.EnumTypes);
            if (codeModel.ShouldGenerateXmlSerialization)
            {
                await GenerateXmlSerialization();
            }
        }

        protected virtual async Task GenerateServiceClient(CodeModelCs codeModel)
        {
            await Write(new ServiceClientTemplate { Model = codeModel }, $"{GeneratedSourcesBaseFolder}{codeModel.Name}{ImplementationFileExtension}");
            await Write(new ServiceClientInterfaceTemplate { Model = codeModel }, $"{GeneratedSourcesBaseFolder}I{codeModel.Name}{ImplementationFileExtension}");
        }

        protected virtual async Task GenerateOperations(CodeModelCs codeModel)
        {
            // Operation
            await Write(
                new AzureMethodGroupTemplate { Model = codeModel },
                $"{GeneratedSourcesBaseFolder}Operations{ImplementationFileExtension}");

            // Operation interface
            await Write(
                new MethodGroupInterfaceTemplate { Model = codeModel },
                $"{GeneratedSourcesBaseFolder}IOperations{ImplementationFileExtension}");
        }

        protected virtual async Task GenerateModels(IEnumerable<CompositeType> modelTypes)
        {
            foreach (CompositeTypeCs model in modelTypes)
            {
                if (true == model.Extensions.Get<bool>(SwaggerExtensions.ExternalExtension))
                {
                    continue;
                }

                await Write(new ModelTemplate{ Model = model },
                    $"{GeneratedSourcesBaseFolder}{FolderModels}/{model.Name}{ImplementationFileExtension}");
            }
        }

        protected virtual async Task GenerateEnums(IEnumerable<EnumType> enumTypes)
        {
            foreach (EnumTypeCs enumType in enumTypes)
            {
                await Write(new ExtensibleEnumTemplate { Model = enumType },
                    $"{GeneratedSourcesBaseFolder}{FolderModels}/{enumType.Name}{ImplementationFileExtension}");
                await Write(new ExtensibleEnumConverterTemplate { Model = enumType },
                    $"{GeneratedSourcesBaseFolder}{FolderModels}/{enumType.Name + "Converter"}{ImplementationFileExtension}");
            }
        }
        
        protected virtual async Task GenerateXmlSerialization()
        {
            await Write(new XmlSerializationTemplate(), 
                $"{GeneratedSourcesBaseFolder}{FolderModels}/{XmlSerialization.XmlDeserializationClass}{ImplementationFileExtension}");
        }

        /// <summary>
        /// Generates C# code for service client.
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public override async Task Generate(CodeModel cm)
        {
            // get c# specific codeModel
            var codeModel = cm as CodeModelCs;
            if (codeModel == null)
            {
                throw new InvalidCastException("CodeModel is not a c# CodeModel");
            }
            await GenerateClientSideCode(codeModel);
        }
    }
}
