using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.Model.Location;

namespace SetlistFmApi.SearchResults.Location
{
    public class VenueSearchResult
    {
        public SearchResultsList<Venue> Venues { get; set; }
    }
}
