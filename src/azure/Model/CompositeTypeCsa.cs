﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Model;

namespace AutoRest.CSharp.Azure.Model
{
    public class CompositeTypeCsa : CompositeTypeCs
    {
        public CompositeTypeCsa() 
        {
        }

        public CompositeTypeCsa(string name ) : base(name)
        {
        }

        /// <summary>
        /// Returns the using statements for the model.
        /// </summary>
        public override IEnumerable<string> Usings => new []{"Microsoft.Rest.Azure"}.Concat(base.Usings);
    }
}
