using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.SearchOptions.Location;
using Xunit;

namespace SetlistFmApi.Tests
{
    public class LocationTests : SetlistFmApiTestBase
    {
        [Fact]
        public void FindCity_ById_CanFindCity()
        {
            string id = "5392171";

            var city = _client.FindCity(id);

            Assert.Equal("San Jose", city.Name);
        }

        [Fact]
        public void FindCountries_CanFindCountries()
        {
            var options = new CountrySearchOptions();

            var results = _client.FindCountries(options);

            Assert.NotEqual(0, results.Countries.Count);
        }

        [Fact]
        public void FindVenues_CanFindVenues()
        {
            var options = new VenueSearchOptions()
                              {
                                  Name = "Terminal 5"
                              };

            var results = _client.FindVenues(options);

            Assert.NotEmpty(results.Venues);
        }
    }
}
