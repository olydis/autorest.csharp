// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.Fluent.AzureResource.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class FlattenedProduct : Resource
    {
        /// <summary>
        /// Initializes a new instance of the FlattenedProduct class.
        /// </summary>
        public FlattenedProduct()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the FlattenedProduct class.
        /// </summary>
        /// <param name="id">Resource Id</param>
        /// <param name="type">Resource Type</param>
        /// <param name="location">Resource Location</param>
        /// <param name="name">Resource Name</param>
        public FlattenedProduct(string id = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string location = default(string), string name = default(string), FlattenedResourceProperties properties = default(FlattenedResourceProperties))
            : base(id, type, tags, location, name)
        {
            Properties = properties;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public FlattenedResourceProperties Properties { get; set; }

    }
}
