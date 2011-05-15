using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using SetlistFmApi.Model.Location;
using SetlistFmApi.SearchOptions.Location;
using SetlistFmApi.SearchResults.Location;
using SetlistFmApi.SearchResults.Music;

namespace SetlistFmApi
{
    public partial class SetlistFmApi
    {
#if (!__ANDROID__ && !SILVERLIGHT && !WINDOWS_PHONE)
        public City FindCity(string cityId)
        {
            var request = createCityIdRequest(cityId);

            return executeRequest<City>(request);
        }

        public CountrySearchResult FindCountries()
        {
            var request = createCountrySearchRequest();

            return executeRequest<CountrySearchResult>(request);
        }

        public Venue FindVenue(string venueId)
        {
            var request = createVenueIdRequest(venueId);

            return executeRequest<Venue>(request);
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

        public SetlistSearchResult FindSetlistsByVenue(SetlistByVenueSearchOptions options)
        {
            var request = createSetlistByVenueSearchRequest(options);

            return executeRequest<SetlistSearchResult>(request);
        }
#endif

        private RestRequest createVenueIdRequest(string venueId)
        {
            var request = new RestRequest();
            request.Resource = "venue/{VenueId}";

            request.AddUrlSegment("VenueId", venueId);

            return request;
        }

        private RestRequest createCountrySearchRequest()
        {
            var request = new RestRequest();
            request.Resource = "search/countries";

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

            return request;
        }

        private RestRequest createCityIdRequest(string cityId)
        {
            var request = new RestRequest();
            request.Resource = "city/{CityId}";

            request.AddUrlSegment("CityId", cityId);

            return request;
        }

        private RestRequest createSetlistByVenueSearchRequest(SetlistByVenueSearchOptions options)
        {
            var request = new RestRequest();
            request.Resource = "venue/{VenueId}/setlists";

            request.AddUrlSegment("VenueId", options.VenueId);

            if (options.Page.HasValue)
                request.AddParameter("p", options.Page.Value);

            return request;
        }
    }
}
