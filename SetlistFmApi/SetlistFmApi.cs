using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using SetlistFmApi.Deserialization;

namespace SetlistFmApi
{
    public partial class SetlistFmApi
    {
        private const string _baseUrl = "http://api.setlist.fm/rest/0.1";
        private RestClient _client;
        private readonly string _apiKey;
        private SetlistFmXmlDeserializer _deserializer;

        public SetlistFmApi(string apiKey)
        {
            _deserializer = new SetlistFmXmlDeserializer();
            _apiKey = apiKey;
            _client = new RestClient();
            _client.BaseUrl = _baseUrl;

            _client.ClearHandlers();
            _client.AddHandler("text/xml", _deserializer);
            _client.AddHandler("application/xml", _deserializer);
            _client.AddHandler("*", _deserializer);
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
            request.DateFormat = "dd-MM-yyyy";
        }
    }
}
