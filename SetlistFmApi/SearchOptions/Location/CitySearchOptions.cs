using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetlistFmApi.SearchOptions.Location
{
    public class CitySearchOptions : ListOptionsBase
    {
        public string Name { get; set; }

        public string StateCode { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string LanguageCode { get; set; }
    }
}
