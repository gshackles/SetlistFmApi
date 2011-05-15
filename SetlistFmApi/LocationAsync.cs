using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.Model.Location;
using SetlistFmApi.SearchOptions.Location;
using SetlistFmApi.SearchResults.Location;
using SetlistFmApi.SearchResults.Music;

namespace SetlistFmApi
{
    public partial class SetlistFmApi
    {
        public void FindCityAsync(string cityId, Action<City> callback)
        {
            var request = createCityIdRequest(cityId);

            executeRequestAsync<City>(request, callback);
        }

        public void FindCountriesAsync(Action<CountrySearchResult> callback)
        {
            var request = createCountrySearchRequest();

            executeRequestAsync<CountrySearchResult>(request, callback);
        }

        public void FindVenueAsync(string venueId, Action<Venue> callback)
        {
            var request = createVenueIdRequest(venueId);

            executeRequestAsync<Venue>(request, callback);
        }

        public void FindVenuesAsync(VenueSearchOptions options, Action<VenueSearchResult> callback)
        {
            var request = createVenueSearchRequest(options);

            executeRequestAsync<VenueSearchResult>(request, callback);
        }

        public void FindCities(CitySearchOptions options, Action<CitySearchResult> callback)
        {
            var request = createCitySearchRequest(options);

            executeRequestAsync<CitySearchResult>(request, callback);
        }

        public void FindSetlistsByVenue(SetlistByVenueSearchOptions options, Action<SetlistSearchResult> callback)
        {
            var request = createSetlistByVenueSearchRequest(options);

            executeRequestAsync<SetlistSearchResult>(request, callback);
        }
    }
}
