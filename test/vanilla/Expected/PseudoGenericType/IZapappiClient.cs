// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Zapappi.Client
{
    using Models;
    using Newtonsoft.Json;

    /// <summary>
    /// This is a test API.
    /// </summary>
    public partial interface IZapappiClient : System.IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }


        /// <summary>
        /// Gets the IApplications.
        /// </summary>
        IApplications Applications { get; }

        /// <summary>
        /// Gets the IContacts.
        /// </summary>
        IContacts Contacts { get; }

        /// <summary>
        /// Gets the IDomains.
        /// </summary>
        IDomains Domains { get; }

        /// <summary>
        /// Gets the IInbound.
        /// </summary>
        IInbound Inbound { get; }

        /// <summary>
        /// Gets the INumbers.
        /// </summary>
        INumbers Numbers { get; }

        /// <summary>
        /// Gets the IPorting.
        /// </summary>
        IPorting Porting { get; }

        /// <summary>
        /// Gets the ISMS.
        /// </summary>
        ISMS SMS { get; }

        /// <summary>
        /// Gets the ITrunks.
        /// </summary>
        ITrunks Trunks { get; }

    }
}