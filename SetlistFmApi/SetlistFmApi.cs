using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace SetlistFmApi
{
    public partial class SetlistFmApi
    {
        private const string _baseUrl = "http://api.setlist.fm/rest/0.1";
        private RestClient _client;
        private readonly string _apiKey;

        public SetlistFmApi(string apiKey)
        {
            _apiKey = apiKey;
            _client = new RestClient();
            _client.BaseUrl = _baseUrl;
        }

#if (!__ANDROID__ && !SILVERLIGHT && !WINDOWS_PHONE)
        private T executeRequest<T>(RestRequest request) where T : new()
        {
            return _client.Execute<T>(request).Data;
        }
#endif

        private void executeRequestAsync<T>(RestRequest request, Action<T> callback) where T : new()
        {
            _client.ExecuteAsync<T>(request, response => callback(response.Data));
        }
    }
}
