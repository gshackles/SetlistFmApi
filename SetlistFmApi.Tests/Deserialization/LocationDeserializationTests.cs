using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.Model;
using SetlistFmApi.Model.Location;
using SetlistFmApi.SearchResults.Location;
using Xunit;

namespace SetlistFmApi.Tests.Deserialization
{
    public class LocationDeserializationTests : DeserializationTestBase
    {
        [Fact]
        public void Can_Deserialize_City()
        {
            var city = deserializeFromFile<City>("city_sanjose.xml");

            Assert.NotNull(city);
            Assert.Equal("CA", city.StateCode);
            Assert.Equal("California", city.State);
            Assert.Equal("San Jose", city.Name);
            Assert.Equal("5392171", city.Id);
            Assert.Equal(-121.8949555, city.Coords.Long);
            Assert.Equal(37.3393857, city.Coords.Lat);
            Assert.Equal("United States", city.Country.Name);
            Assert.Equal("US", city.Country.Code);
        }

        //[Fact]
        // Not implementing this yet, see http://www.setlist.fm/forum/setlistfm/setlistfm-api/question-about-cities-schema-3bd6bc1c
        public void Can_Deserialize_City_Search_Results()
        {
            var result = deserializeFromFile<CitySearchResult>("city_list.xml");

            Assert.NotNull(result);
            Assert.Equal(3, result.Cities.Count);

            var city = result.Cities.First();

            Assert.Equal("NY", city.StateCode);
            Assert.Equal("New York", city.State);
            Assert.Equal("New York", city.Name);
            Assert.Equal("5128581", city.Id);
        }

        [Fact]
        public void Can_Deserialize_Country_Search_Results()
        {
            var result = deserializeFromFile<CountrySearchResult>("country_list.xml");

            Assert.NotNull(result);
            Assert.Equal(247, result.Countries.Count);

            var country = result.Countries.First();

            Assert.Equal("Andorra", country.Name);
            Assert.Equal("AD", country.Code);
        }

        [Fact]
        public void Can_Deserialize_Venue()
        {
            var venue = deserializeFromFile<Venue>("venue_royalalbert.xml");

            Assert.NotNull(venue);
            Assert.Equal("Royal Albert Hall", venue.Name);
            Assert.Equal("53d63779", venue.Id);
            Assert.Equal("England", venue.City.State);
        }
    }
}
