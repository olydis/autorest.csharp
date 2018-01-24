// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.ContentTypeHeader.Models
{
    using Newtonsoft.Json;

    using System.Reflection;

    /// <summary>
    /// Defines values for ImageType.
    /// </summary>
    public sealed class ImageTypeConverter : JsonConverter
    {

        /// <summary>
        /// Returns if objectType can be converted to ImageType by the
        /// converter.
        /// </summary>
        public override bool CanConvert(System.Type objectType)
        {
            return typeof(ImageType).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        /// <summary>
        /// Overrides ReadJson and converts token to ImageType.
        /// </summary>
        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == Newtonsoft.Json.JsonToken.Null)
            {
                return null;
            }
            return (ImageType)serializer.Deserialize<string>(reader);
        }

        /// <summary>
        /// Overriding WriteJson for ImageType for serialization.
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

    }
}
