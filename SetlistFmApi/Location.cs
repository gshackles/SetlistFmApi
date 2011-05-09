using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using SetlistFmApi.Model;
using SetlistFmApi.Model.Location;
using SetlistFmApi.SearchOptions.Location;
using SetlistFmApi.SearchResults.Location;

namespace SetlistFmApi
{
    public partial class SetlistFmApi
    {
#if (!__ANDROID__ && !SILVERLIGHT && !WINDOWS_PHONE)
        public City FindCity(string id)
        {
            var request = createCityIdRequest(id);

            return executeRequest<City>(request);
        }

        public CountrySearchResult FindCountries(CountrySearchOptions options)
        {
            var request = createCountrySearchRequest(options);

            return executeRequest<CountrySearchResult>(request);
        }
#endif

        private RestRequest createCityIdRequest(string id)
        {
            var request = new RestRequest();
            request.Resource = "city/" + id;

            return request;
        }

        private RestRequest createCountrySearchRequest(CountrySearchOptions options)
        {
            var request = new RestRequest();
            request.Resource = "search/countries";

            if (!string.IsNullOrEmpty(options.LanguageCode))
                request.AddParameter("l", options.LanguageCode);

            return request;
        }
    }
}
