// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

namespace Fixtures.DateTimeOffset
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A sample API that tests datetimeoffset usage for date-time
    /// </summary>
    public partial class SwaggerDateTimeOffsetClient : ServiceClient<SwaggerDateTimeOffsetClient>, ISwaggerDateTimeOffsetClient
    {
        /// <summary>
        /// Gets or sets the base URI of the service.
        /// </summary>
        public System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets JSON serialization settings.
        /// </summary>
        public JsonSerializerSettings SerializationSettings { get; private set; }

        /// <summary>
        /// Gets or sets JSON deserialization settings.
        /// </summary>
        public JsonSerializerSettings DeserializationSettings { get; private set; }

        /// <summary>
        /// Initializes a new instance of the SwaggerDateTimeOffsetClient class.
        /// </summary>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public SwaggerDateTimeOffsetClient(params DelegatingHandler[] handlers) : base(handlers)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the SwaggerDateTimeOffsetClient class.
        /// </summary>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public SwaggerDateTimeOffsetClient(HttpClientHandler rootHandler, params DelegatingHandler[] handlers) : base(rootHandler, handlers)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the SwaggerDateTimeOffsetClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref='System.ArgumentNullException'>
        /// Thrown when a required parameter is null.
        /// </exception>
        public SwaggerDateTimeOffsetClient(System.Uri baseUri, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (baseUri == null)
            {
                throw new System.ArgumentNullException(nameof(baseUri));
            }
            BaseUri = baseUri;
        }

        /// <summary>
        /// Initializes a new instance of the SwaggerDateTimeOffsetClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref='System.ArgumentNullException'>
        /// Thrown when a required parameter is null.
        /// </exception>
        public SwaggerDateTimeOffsetClient(System.Uri baseUri, HttpClientHandler rootHandler, params DelegatingHandler[] handlers) : this(rootHandler, handlers)
        {
            if (baseUri == null)
            {
                throw new System.ArgumentNullException(nameof(baseUri));
            }
            BaseUri = baseUri;
        }

        /// <summary>
        /// An optional partial-method to perform custom initialization.
        /// </summary>
        partial void CustomInitialize();
        /// <summary>
        /// Initializes client properties.
        /// </summary>
        private void Initialize()
        {
            BaseUri = new System.Uri("http://localhost:3000/api");
            SerializationSettings = new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            DeserializationSettings = new JsonSerializerSettings
            {
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            CustomInitialize();
        }
        /// <summary>
        /// Product Types
        /// </summary>
        /// <param name='responseCode'>
        /// The desired returned status code
        /// </param>
        /// <param name='product'>
        /// The only parameter
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref='ErrorException'>
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        /// <exception cref='SerializationException'>
        /// Thrown when unable to deserialize the response.
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse<Product>> GetProductWithHttpMessagesAsync(string responseCode = default(string), Product product = default(Product), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("responseCode", responseCode);
                tracingParameters.Add("product", product);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetProduct", tracingParameters);
            }
            // Construct URL
            var _baseUrl = BaseUri.AbsoluteUri;
            string _url = new System.Uri(new System.Uri(_baseUrl.TrimEnd('/') + "/"), "datatypes").ToString();
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (responseCode != null)
            {
                _httpRequest.Headers.Remove("response-code");
                _httpRequest.Headers.TryAddWithoutValidation("response-code", responseCode);
            }


            if (customHeaders != null)
            {
                foreach (var _header in customHeaders)
                {
                    _httpRequest.Headers.Remove(_header.Key);
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            if (product != null)
            {
                _requestContent = SafeJsonConvert.SerializeObject(product, SerializationSettings);
                _httpRequest.Content = new StringContent(_requestContent, Encoding.UTF8);
                _httpRequest.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            Stream _responseContent = _httpResponse.Content != null
                ? await _httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false)
                : new MemoryStream();
            Encoding _responseContentEncoding = _httpResponse.Content != null && _httpResponse.Content.Headers != null && _httpResponse.Content.Headers.ContentType != null && _httpResponse.Content.Headers.ContentType.CharSet != null
                ? Encoding.GetEncoding(_httpResponse.Content.Headers.ContentType.CharSet)
                : Encoding.UTF8;
            System.IO.TextReader _responseContentTextReader = new System.IO.StreamReader(_responseContent, _responseContentEncoding);
            if ((int)_statusCode != 200)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    Error _errorBody = SafeJsonConvert.DeserializeObject<Error>(_responseContentTextReader.ReadToEnd(), DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContentTextReader.ReadToEnd());
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new HttpOperationResponse<Product>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                try
                {
                    _result.Body = SafeJsonConvert.DeserializeObject<Product>(_responseContentTextReader.ReadToEnd(), DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    string message = _responseContentTextReader.ReadToEnd();
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", message, ex);
                }
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// Product Types
        /// </summary>
        /// <param name='responseCode'>
        /// The desired returned status code
        /// </param>
        /// <param name='product'>
        /// The only parameter
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref='ErrorException'>
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        /// <exception cref='SerializationException'>
        /// Thrown when unable to deserialize the response.
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse<Product>> PutProductWithHttpMessagesAsync(string responseCode = default(string), Product product = default(Product), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("responseCode", responseCode);
                tracingParameters.Add("product", product);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "PutProduct", tracingParameters);
            }
            // Construct URL
            var _baseUrl = BaseUri.AbsoluteUri;
            string _url = new System.Uri(new System.Uri(_baseUrl.TrimEnd('/') + "/"), "datatypes").ToString();
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("PUT");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (responseCode != null)
            {
                _httpRequest.Headers.Remove("response-code");
                _httpRequest.Headers.TryAddWithoutValidation("response-code", responseCode);
            }


            if (customHeaders != null)
            {
                foreach (var _header in customHeaders)
                {
                    _httpRequest.Headers.Remove(_header.Key);
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            if (product != null)
            {
                _requestContent = SafeJsonConvert.SerializeObject(product, SerializationSettings);
                _httpRequest.Content = new StringContent(_requestContent, Encoding.UTF8);
                _httpRequest.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            Stream _responseContent = _httpResponse.Content != null
                ? await _httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false)
                : new MemoryStream();
            Encoding _responseContentEncoding = _httpResponse.Content != null && _httpResponse.Content.Headers != null && _httpResponse.Content.Headers.ContentType != null && _httpResponse.Content.Headers.ContentType.CharSet != null
                ? Encoding.GetEncoding(_httpResponse.Content.Headers.ContentType.CharSet)
                : Encoding.UTF8;
            System.IO.TextReader _responseContentTextReader = new System.IO.StreamReader(_responseContent, _responseContentEncoding);
            if ((int)_statusCode != 200)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    Error _errorBody = SafeJsonConvert.DeserializeObject<Error>(_responseContentTextReader.ReadToEnd(), DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContentTextReader.ReadToEnd());
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new HttpOperationResponse<Product>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                try
                {
                    _result.Body = SafeJsonConvert.DeserializeObject<Product>(_responseContentTextReader.ReadToEnd(), DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    string message = _responseContentTextReader.ReadToEnd();
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", message, ex);
                }
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// Product Types
        /// </summary>
        /// <param name='responseCode'>
        /// The desired returned status code
        /// </param>
        /// <param name='product'>
        /// The only parameter
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref='ErrorException'>
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        /// <exception cref='SerializationException'>
        /// Thrown when unable to deserialize the response.
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse<Product>> PostProductWithHttpMessagesAsync(string responseCode = default(string), Product product = default(Product), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("responseCode", responseCode);
                tracingParameters.Add("product", product);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "PostProduct", tracingParameters);
            }
            // Construct URL
            var _baseUrl = BaseUri.AbsoluteUri;
            string _url = new System.Uri(new System.Uri(_baseUrl.TrimEnd('/') + "/"), "datatypes").ToString();
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("POST");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (responseCode != null)
            {
                _httpRequest.Headers.Remove("response-code");
                _httpRequest.Headers.TryAddWithoutValidation("response-code", responseCode);
            }


            if (customHeaders != null)
            {
                foreach (var _header in customHeaders)
                {
                    _httpRequest.Headers.Remove(_header.Key);
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            if (product != null)
            {
                _requestContent = SafeJsonConvert.SerializeObject(product, SerializationSettings);
                _httpRequest.Content = new StringContent(_requestContent, Encoding.UTF8);
                _httpRequest.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            Stream _responseContent = _httpResponse.Content != null
                ? await _httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false)
                : new MemoryStream();
            Encoding _responseContentEncoding = _httpResponse.Content != null && _httpResponse.Content.Headers != null && _httpResponse.Content.Headers.ContentType != null && _httpResponse.Content.Headers.ContentType.CharSet != null
                ? Encoding.GetEncoding(_httpResponse.Content.Headers.ContentType.CharSet)
                : Encoding.UTF8;
            System.IO.TextReader _responseContentTextReader = new System.IO.StreamReader(_responseContent, _responseContentEncoding);
            if ((int)_statusCode != 200)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    Error _errorBody = SafeJsonConvert.DeserializeObject<Error>(_responseContentTextReader.ReadToEnd(), DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContentTextReader.ReadToEnd());
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new HttpOperationResponse<Product>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                try
                {
                    _result.Body = SafeJsonConvert.DeserializeObject<Product>(_responseContentTextReader.ReadToEnd(), DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    string message = _responseContentTextReader.ReadToEnd();
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", message, ex);
                }
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// Product Types
        /// </summary>
        /// <param name='responseCode'>
        /// The desired returned status code
        /// </param>
        /// <param name='product'>
        /// The only parameter
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref='ErrorException'>
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        /// <exception cref='SerializationException'>
        /// Thrown when unable to deserialize the response.
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse<Product>> PatchProductWithHttpMessagesAsync(string responseCode = default(string), Product product = default(Product), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("responseCode", responseCode);
                tracingParameters.Add("product", product);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "PatchProduct", tracingParameters);
            }
            // Construct URL
            var _baseUrl = BaseUri.AbsoluteUri;
            string _url = new System.Uri(new System.Uri(_baseUrl.TrimEnd('/') + "/"), "datatypes").ToString();
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("PATCH");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (responseCode != null)
            {
                _httpRequest.Headers.Remove("response-code");
                _httpRequest.Headers.TryAddWithoutValidation("response-code", responseCode);
            }


            if (customHeaders != null)
            {
                foreach (var _header in customHeaders)
                {
                    _httpRequest.Headers.Remove(_header.Key);
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            if (product != null)
            {
                _requestContent = SafeJsonConvert.SerializeObject(product, SerializationSettings);
                _httpRequest.Content = new StringContent(_requestContent, Encoding.UTF8);
                _httpRequest.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            Stream _responseContent = _httpResponse.Content != null
                ? await _httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false)
                : new MemoryStream();
            Encoding _responseContentEncoding = _httpResponse.Content != null && _httpResponse.Content.Headers != null && _httpResponse.Content.Headers.ContentType != null && _httpResponse.Content.Headers.ContentType.CharSet != null
                ? Encoding.GetEncoding(_httpResponse.Content.Headers.ContentType.CharSet)
                : Encoding.UTF8;
            System.IO.TextReader _responseContentTextReader = new System.IO.StreamReader(_responseContent, _responseContentEncoding);
            if ((int)_statusCode != 200)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    Error _errorBody = SafeJsonConvert.DeserializeObject<Error>(_responseContentTextReader.ReadToEnd(), DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContentTextReader.ReadToEnd());
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new HttpOperationResponse<Product>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                try
                {
                    _result.Body = SafeJsonConvert.DeserializeObject<Product>(_responseContentTextReader.ReadToEnd(), DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    string message = _responseContentTextReader.ReadToEnd();
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", message, ex);
                }
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

    }
}
