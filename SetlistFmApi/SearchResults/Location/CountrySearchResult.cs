using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.Model.Location;

namespace SetlistFmApi.SearchResults.Location
{
    public class CountrySearchResult
    {
        public SearchResultsList<Country> Countries { get; set; }
    }
}
