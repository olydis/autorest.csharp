// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Header.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines values for GreyscaleColors.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    [JsonConverter(typeof(GreyscaleColorsConverter))]
    public struct GreyscaleColors : System.IEquatable<GreyscaleColors>
    {
        private GreyscaleColors(string underlyingValue)
        {
            UnderlyingValue=underlyingValue;
        }

        public static readonly GreyscaleColors White = "White";

        public static readonly GreyscaleColors Black = "black";

        public static readonly GreyscaleColors GREY = "GREY";


        /// <summary>
        /// Underlying value of enum GreyscaleColors
        /// </summary>
        private readonly string UnderlyingValue;

        /// <summary>
        /// Returns string representation for GreyscaleColors
        /// </summary>
        public override string ToString()
        {
            return UnderlyingValue.ToString();
        }

        /// <summary>
        /// Compares enums of type GreyscaleColors
        /// </summary>
        public bool Equals(GreyscaleColors e)
        {
            return UnderlyingValue.Equals(e.UnderlyingValue);
        }

        /// <summary>
        /// Implicit operator to convert string to GreyscaleColors
        /// </summary>
        public static implicit operator GreyscaleColors(string value)
        {
            return new GreyscaleColors(value);
        }

        /// <summary>
        /// Implicit operator to convert GreyscaleColors to string
        /// </summary>
        public static implicit operator string(GreyscaleColors e)
        {
            return e.UnderlyingValue;
        }

        /// <summary>
        /// Overriding == operator for enum GreyscaleColors
        /// </summary>
        public static bool operator == (GreyscaleColors e1, GreyscaleColors e2)
        {
            return e2.Equals(e1);
        }

        /// <summary>
        /// Overriding != operator for enum GreyscaleColors
        /// </summary>
        public static bool operator != (GreyscaleColors e1, GreyscaleColors e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>
        /// Overrides Equals operator for GreyscaleColors
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is GreyscaleColors && Equals((GreyscaleColors)obj);
        }

        /// <summary>
        /// Returns for hashCode GreyscaleColors
        /// </summary>
        public override int GetHashCode()
        {
            return UnderlyingValue.GetHashCode();
        }

    }
}
