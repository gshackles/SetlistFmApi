using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.Model.Music;

namespace SetlistFmApi.SearchResults.Music
{
    public class ArtistSearchResult
    {
        public SearchResultsList<Artist> Artists { get; set; }
    }
}
