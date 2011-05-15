using System;
using System.Collections.Generic;
using System.Linq;

namespace SetlistFmApi.SearchOptions.Location
{
    public class VenueSearchOptions : ListOptionsBase
    {
        public string Name { get; set; }

        public string CityName { get; set; }

        public string CityId { get; set; }

        public string StateCode { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
    }
}
