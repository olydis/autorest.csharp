// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using AutoRest.Core;
using AutoRest.Core.Extensibility;

namespace AutoRest.CSharp
{
    public class GeneratorSettingsCs : IGeneratorSettings
    {
        public bool UseDateTimeOffset { get; set; }

        public bool ClientSideValidation { get; set; }
    }
}