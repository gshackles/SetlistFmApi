using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.Model.Music;
using SetlistFmApi.SearchOptions.Music;
using SetlistFmApi.SearchResults.Music;

namespace SetlistFmApi
{
    public partial class SetlistFmApi
    {
        public void FindArtistsAsync(ArtistSearchOptions options, Action<ArtistSearchResult> callback)
        {
            var request = createArtistSearchRequest(options);

            executeRequestAsync<ArtistSearchResult>(request, callback);
        }

        public void FindArtistAsync(string id, Action<Artist> callback)
        {
            var request = createArtistIdRequest(id);

            executeRequestAsync<Artist>(request, callback);
        }
    }
}
