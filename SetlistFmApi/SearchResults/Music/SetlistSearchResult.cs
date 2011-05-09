using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.Model.Music;

namespace SetlistFmApi.SearchResults.Music
{
    public class SetlistSearchResult
    {
        public SearchResultsList<Setlist> Setlists { get; set; }
    }
}
