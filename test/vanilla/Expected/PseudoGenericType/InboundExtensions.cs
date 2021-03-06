// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Zapappi.Client
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Inbound.
    /// </summary>
    public static partial class InboundExtensions
    {
            /// <summary>
            /// Get Endpoints from Inbound Platform
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='take'>
            /// </param>
            /// <param name='skip'>
            /// </param>
            /// <param name='search'>
            /// </param>
            public static PagedResponse<EndpointViewModel> GetEndpoints(this IInbound operations, string subscriptionId, int? take = default(int?), int? skip = default(int?), string search = default(string))
            {
                return operations.GetEndpointsAsync(subscriptionId, take, skip, search).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get Endpoints from Inbound Platform
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='take'>
            /// </param>
            /// <param name='skip'>
            /// </param>
            /// <param name='search'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<PagedResponse<EndpointViewModel>> GetEndpointsAsync(this IInbound operations, string subscriptionId, int? take = default(int?), int? skip = default(int?), string search = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetEndpointsWithHttpMessagesAsync(subscriptionId, take, skip, search, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get Simple Endpoint Details
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='endpointId'>
            /// </param>
            public static SimpleEndpointModel GetSimpleEndpoint(this IInbound operations, string subscriptionId, string endpointId)
            {
                return operations.GetSimpleEndpointAsync(subscriptionId, endpointId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get Simple Endpoint Details
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='endpointId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<SimpleEndpointModel> GetSimpleEndpointAsync(this IInbound operations, string subscriptionId, string endpointId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetSimpleEndpointWithHttpMessagesAsync(subscriptionId, endpointId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Update Simple Endpoint
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='model'>
            /// </param>
            public static SimpleEndpointModel UpdateSimpleEndpoint(this IInbound operations, string subscriptionId, SimpleEndpointModel model)
            {
                return operations.UpdateSimpleEndpointAsync(subscriptionId, model).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Update Simple Endpoint
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='model'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<SimpleEndpointModel> UpdateSimpleEndpointAsync(this IInbound operations, string subscriptionId, SimpleEndpointModel model, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateSimpleEndpointWithHttpMessagesAsync(subscriptionId, model, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Create Simple Endpoint
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='description'>
            /// </param>
            /// <param name='forwardUri'>
            /// </param>
            /// <param name='username'>
            /// </param>
            /// <param name='password'>
            /// </param>
            /// <param name='proxyUri'>
            /// </param>
            public static SimpleEndpointModel CreateSimpleEndpoint(this IInbound operations, string subscriptionId, string description, string forwardUri, string username = default(string), string password = default(string), string proxyUri = default(string))
            {
                return operations.CreateSimpleEndpointAsync(subscriptionId, description, forwardUri, username, password, proxyUri).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create Simple Endpoint
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='description'>
            /// </param>
            /// <param name='forwardUri'>
            /// </param>
            /// <param name='username'>
            /// </param>
            /// <param name='password'>
            /// </param>
            /// <param name='proxyUri'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<SimpleEndpointModel> CreateSimpleEndpointAsync(this IInbound operations, string subscriptionId, string description, string forwardUri, string username = default(string), string password = default(string), string proxyUri = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateSimpleEndpointWithHttpMessagesAsync(subscriptionId, description, forwardUri, username, password, proxyUri, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get Mappings from Inbound Platform
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='take'>
            /// </param>
            /// <param name='skip'>
            /// </param>
            /// <param name='search'>
            /// </param>
            /// <param name='withoutEndpoint'>
            /// </param>
            public static PagedResponse<EndpointMappingViewModel> GetMappings(this IInbound operations, string subscriptionId, int? take = default(int?), int? skip = default(int?), string search = default(string), bool? withoutEndpoint = default(bool?))
            {
                return operations.GetMappingsAsync(subscriptionId, take, skip, search, withoutEndpoint).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get Mappings from Inbound Platform
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='take'>
            /// </param>
            /// <param name='skip'>
            /// </param>
            /// <param name='search'>
            /// </param>
            /// <param name='withoutEndpoint'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<PagedResponse<EndpointMappingViewModel>> GetMappingsAsync(this IInbound operations, string subscriptionId, int? take = default(int?), int? skip = default(int?), string search = default(string), bool? withoutEndpoint = default(bool?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetMappingsWithHttpMessagesAsync(subscriptionId, take, skip, search, withoutEndpoint, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='domain'>
            /// </param>
            /// <param name='match'>
            /// </param>
            /// <param name='endpointId'>
            /// </param>
            /// <param name='isDefault'>
            /// </param>
            /// <param name='cvar1'>
            /// </param>
            /// <param name='cvar2'>
            /// </param>
            public static EndpointMappingViewModel AddMapping(this IInbound operations, string subscriptionId, string domain, string match, string endpointId, bool isDefault, string cvar1, string cvar2)
            {
                return operations.AddMappingAsync(subscriptionId, domain, match, endpointId, isDefault, cvar1, cvar2).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='domain'>
            /// </param>
            /// <param name='match'>
            /// </param>
            /// <param name='endpointId'>
            /// </param>
            /// <param name='isDefault'>
            /// </param>
            /// <param name='cvar1'>
            /// </param>
            /// <param name='cvar2'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<EndpointMappingViewModel> AddMappingAsync(this IInbound operations, string subscriptionId, string domain, string match, string endpointId, bool isDefault, string cvar1, string cvar2, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.AddMappingWithHttpMessagesAsync(subscriptionId, domain, match, endpointId, isDefault, cvar1, cvar2, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get a specific Mapping from Inbound Platform by Id
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='id'>
            /// </param>
            public static EndpointMappingViewModel GetMapping(this IInbound operations, string subscriptionId, System.Guid id)
            {
                return operations.GetMappingAsync(subscriptionId, id).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a specific Mapping from Inbound Platform by Id
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<EndpointMappingViewModel> GetMappingAsync(this IInbound operations, string subscriptionId, System.Guid id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetMappingWithHttpMessagesAsync(subscriptionId, id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='endpointId'>
            /// </param>
            public static EndpointMappingViewModel UpdateMapping(this IInbound operations, string subscriptionId, string id, string endpointId)
            {
                return operations.UpdateMappingAsync(subscriptionId, id, endpointId).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='subscriptionId'>
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='endpointId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<EndpointMappingViewModel> UpdateMappingAsync(this IInbound operations, string subscriptionId, string id, string endpointId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateMappingWithHttpMessagesAsync(subscriptionId, id, endpointId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
