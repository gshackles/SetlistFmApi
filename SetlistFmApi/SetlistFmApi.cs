using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using SetlistFmApi.Deserialization;
using SetlistFmApi.Deserialization.Xml;
using SetlistFmApi.Deserialization.Json;

namespace SetlistFmApi
{
    public partial class SetlistFmApi
    {
        private const string _baseUrl = "http://api.setlist.fm/rest/0.1";
        private RestClient _client;
        private readonly string _apiKey;
        private SetlistFmXmlDeserializer _xmlDeserializer;
        private SetlistFmJsonDeserializer _jsonDeserializer;

        public DataFormat Format { get; set; }

        public SetlistFmApi(string apiKey)
        {
            _xmlDeserializer = new SetlistFmXmlDeserializer();
            _jsonDeserializer = new SetlistFmJsonDeserializer();
            _apiKey = apiKey;
            _client = new RestClient();
            _client.BaseUrl = _baseUrl;
            Format = DataFormat.Xml;

            _client.ClearHandlers();
            _client.AddHandler("text/xml", _xmlDeserializer);
            _client.AddHandler("application/xml", _xmlDeserializer);
            _client.AddHandler("application/json", _jsonDeserializer);
            _client.AddHandler("text/json", _jsonDeserializer);
            _client.AddHandler("text/x-json", _jsonDeserializer);
            _client.AddHandler("text/javascript", _jsonDeserializer);
            _client.AddHandler("*", _xmlDeserializer);
        }

#if (!__ANDROID__ && !SILVERLIGHT && !WINDOWS_PHONE)
        private T executeRequest<T>(RestRequest request) where T : new()
        {
            prepareRequest(request);

            return _client.Execute<T>(request).Data;
        }
#endif

        private void executeRequestAsync<T>(RestRequest request, Action<T> callback) where T : new()
        {
            prepareRequest(request);

            _client.ExecuteAsync<T>(request, response => callback(response.Data));
        }

        private void prepareRequest(RestRequest request)
        {
            request.RequestFormat = Format;
            request.DateFormat = "dd-MM-yyyy";
        }
    }
}
