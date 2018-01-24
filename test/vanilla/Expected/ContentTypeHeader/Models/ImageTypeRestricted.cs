// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.ContentTypeHeader.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines values for ImageTypeRestricted.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    [JsonConverter(typeof(ImageTypeRestrictedConverter))]
    public struct ImageTypeRestricted : System.IEquatable<ImageTypeRestricted>
    {
        private ImageTypeRestricted(string underlyingValue)
        {
            UnderlyingValue=underlyingValue;
        }

        public static readonly ImageTypeRestricted ImagePng = "image/png";

        public static readonly ImageTypeRestricted ImageTiff = "image/tiff";


        /// <summary>
        /// Underlying value of enum ImageTypeRestricted
        /// </summary>
        private readonly string UnderlyingValue;

        /// <summary>
        /// Returns string representation for ImageTypeRestricted
        /// </summary>
        public override string ToString()
        {
            return UnderlyingValue.ToString();
        }

        /// <summary>
        /// Compares enums of type ImageTypeRestricted
        /// </summary>
        public bool Equals(ImageTypeRestricted e)
        {
            return UnderlyingValue.Equals(e.UnderlyingValue);
        }

        /// <summary>
        /// Implicit operator to convert string to ImageTypeRestricted
        /// </summary>
        public static implicit operator ImageTypeRestricted(string value)
        {
            return new ImageTypeRestricted(value);
        }

        /// <summary>
        /// Implicit operator to convert ImageTypeRestricted to string
        /// </summary>
        public static implicit operator string(ImageTypeRestricted e)
        {
            return e.UnderlyingValue;
        }

        /// <summary>
        /// Overriding == operator for enum ImageTypeRestricted
        /// </summary>
        public static bool operator == (ImageTypeRestricted e1, ImageTypeRestricted e2)
        {
            return e2.Equals(e1);
        }

        /// <summary>
        /// Overriding != operator for enum ImageTypeRestricted
        /// </summary>
        public static bool operator != (ImageTypeRestricted e1, ImageTypeRestricted e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>
        /// Overrides Equals operator for ImageTypeRestricted
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is ImageTypeRestricted && Equals((ImageTypeRestricted)obj);
        }

        /// <summary>
        /// Returns for hashCode ImageTypeRestricted
        /// </summary>
        public override int GetHashCode()
        {
            return UnderlyingValue.GetHashCode();
        }

    }
}