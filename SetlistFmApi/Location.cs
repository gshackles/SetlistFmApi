using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
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

        public VenueSearchResult FindVenues(VenueSearchOptions options)
        {
            var request = createVenueSearchRequest(options);

            return executeRequest<VenueSearchResult>(request);
        }

        public CitySearchResult FindCities(CitySearchOptions options)
        {
            var request = createCitySearchRequest(options);

            return executeRequest<CitySearchResult>(request);
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

        private RestRequest createVenueSearchRequest(VenueSearchOptions options)
        {
            var request = new RestRequest();
            request.Resource = "search/venues";

            if (!string.IsNullOrEmpty(options.Name))
                request.AddParameter("name", options.Name);

            if (!string.IsNullOrEmpty(options.CityName))
                request.AddParameter("cityName", options.CityName);

            if (!string.IsNullOrEmpty(options.CityId))
                request.AddParameter("cityId", options.CityId);

            if (!string.IsNullOrEmpty(options.StateCode))
                request.AddParameter("stateCode", options.StateCode);

            if (!string.IsNullOrEmpty(options.State))
                request.AddParameter("state", options.State);

            if (!string.IsNullOrEmpty(options.Country))
                request.AddParameter("country", options.Country);

            if (options.Page.HasValue)
                request.AddParameter("p", options.Page.Value);

            if (!string.IsNullOrEmpty(options.LanguageCode))
                request.AddParameter("l", options.LanguageCode);

            return request;
        }

        private RestRequest createCitySearchRequest(CitySearchOptions options)
        {
            var request = new RestRequest();
            request.Resource = "search/venues";

            if (!string.IsNullOrEmpty(options.Name))
                request.AddParameter("name", options.Name);

            if (!string.IsNullOrEmpty(options.StateCode))
                request.AddParameter("stateCode", options.StateCode);

            if (!string.IsNullOrEmpty(options.State))
                request.AddParameter("state", options.State);

            if (!string.IsNullOrEmpty(options.Country))
                request.AddParameter("country", options.Country);

            if (options.Page.HasValue)
                request.AddParameter("p", options.Page.Value);

            if (!string.IsNullOrEmpty(options.LanguageCode))
                request.AddParameter("l", options.LanguageCode);

            return request;
        }
    }
}
