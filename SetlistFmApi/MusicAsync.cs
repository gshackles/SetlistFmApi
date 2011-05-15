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

        public void FindArtistAsync(string mbId, Action<Artist> callback)
        {
            var request = createArtistIdRequest(mbId);

            executeRequestAsync<Artist>(request, callback);
        }

        public void FindSetlistsAsync(SetlistSearchOptions options, Action<SetlistSearchResult> callback)
        {
            var request = createSetlistSearchRequest(options);

            executeRequestAsync<SetlistSearchResult>(request, callback);
        }

        public void FindSetlistsByArtistAsync(SetlistByArtistSearchOptions options, Action<SetlistSearchResult> callback)
        {
            var request = createSetlistByArtistRequest(options);

            executeRequestAsync<SetlistSearchResult>(request, callback);
        }

        public void FindSetlistAsync(string setlistId, Action<Setlist> callback)
        {
            var request = createSetlistIdRequest(setlistId);

            executeRequestAsync<Setlist>(request, callback);
        }

        public void FindSetlistByLastFmEventAsync(string lastFmEventId, Action<Setlist> callback)
        {
            var request = createSetlistByLastFmEventRequest(lastFmEventId);

            executeRequestAsync<Setlist>(request, callback);
        }

        public void FindSetlistByVersionAsync(string versionId, Action<Setlist> callback)
        {
            var request = createSetlistByVersionRequest(versionId);

            executeRequestAsync<Setlist>(request, callback);
        }

        public void FindSetlistsByTour(SetlistByTourSearchOptions options, Action<SetlistSearchResult> callback)
        {
            var request = createSetlistByTourSearchRequest(options);

            executeRequestAsync<SetlistSearchResult>(request, callback);
        }
    }
}
