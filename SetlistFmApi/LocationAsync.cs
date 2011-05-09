using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.Model.Location;
using SetlistFmApi.SearchOptions.Location;
using SetlistFmApi.SearchResults.Location;

namespace SetlistFmApi
{
    public partial class SetlistFmApi
    {
        public void FindCityAsync(string id, Action<City> callback)
        {
            var request = createCityIdRequest(id);

            executeRequestAsync<City>(request, callback);
        }

        public void FindCountriesAsync(CountrySearchOptions options, Action<CountrySearchResult> callback)
        {
            var request = createCountrySearchRequest(options);

            executeRequestAsync<CountrySearchResult>(request, callback);
        }
    }
}
