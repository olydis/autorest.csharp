using System;
using AutoRest.Core;
using AutoRest.Core.Model;
using AutoRest.Core.Utilities;
using static AutoRest.Core.Utilities.DependencyInjection;
using System.Collections.Generic;

namespace AutoRest.CSharp.Model
{
    public partial class MethodGroupCs : Core.Model.MethodGroup
    {
        protected MethodGroupCs() : base()
        {
        }
        protected MethodGroupCs(string name) : base(name)
        {
        }

        public override IEnumerable<string> Usings
        {
            get
            {
                if ((CodeModel as CodeModelCs).HaveModelNamespace)
                {
                    yield return CodeModel.ModelsName;
                }
            }
        }
    }
}
