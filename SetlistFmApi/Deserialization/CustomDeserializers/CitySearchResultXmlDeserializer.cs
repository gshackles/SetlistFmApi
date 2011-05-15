using System.Linq;
using System.Xml.Linq;
using RestSharp;
using SetlistFmApi.Model.Location;
using SetlistFmApi.SearchResults;
using SetlistFmApi.SearchResults.Location;

namespace SetlistFmApi.Deserialization.CustomDeserializers
{
    public class CitySearchResultXmlDeserializer : ICustomXmlDeserializer
    {
        public object Deserialize(RestResponse response)
        {
            var root = XDocument.Parse(response.Content).Root;
            var cities = root.Descendants("cities");

            var result = new CitySearchResult()
            {
                Cities = new SearchResultsList<City>()
                {
                    Total = int.Parse(root.Attribute("total").Value),
                    Page = int.Parse(root.Attribute("page").Value),
                    ItemsPerPage = int.Parse(root.Attribute("itemsPerPage").Value)
                }
            };

            result.Cities.AddRange(cities.Select(city => new City()
            {
                State = city.Attribute("state").Value,
                StateCode = city.Attribute("stateCode").Value,
                Name = city.Attribute("name").Value,
                Id = city.Attribute("id").Value,
                Coords = new Coordinates()
                {
                    Lat = double.Parse(city.Element("coords").Attribute("lat").Value),
                    Long = double.Parse(city.Element("coords").Attribute("long").Value)
                },
                Country = new Country()
                {
                    Code = city.Element("country").Attribute("code").Value,
                    Name = city.Element("country").Attribute("name").Value
                }
            }));

            return result;
        }
    }
}
