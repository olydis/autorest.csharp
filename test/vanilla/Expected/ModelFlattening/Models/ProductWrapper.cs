// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.ModelFlattening.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The wrapped produc.
    /// </summary>
    public partial class ProductWrapper
    {
        /// <summary>
        /// Initializes a new instance of the ProductWrapper class.
        /// </summary>
        public ProductWrapper()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ProductWrapper class.
        /// </summary>
        public ProductWrapper(WrappedProduct property = default(WrappedProduct))
        {
            Property = property;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "property")]
        public WrappedProduct Property { get; set; }

    }
}
