using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using SetlistFmApi.Model;
using SetlistFmApi.Model.Music;
using SetlistFmApi.SearchOptions.Music;
using SetlistFmApi.SearchResults.Music;

namespace SetlistFmApi
{
    public partial class SetlistFmApi
    {
#if (!__ANDROID__ && !SILVERLIGHT && !WINDOWS_PHONE)
        public ArtistSearchResult FindArtists(ArtistSearchOptions options)
        {
            var request = createArtistSearchRequest(options);

            return executeRequest<ArtistSearchResult>(request);
        }

        public Artist FindArtist(string id)
        {
            var request = createArtistIdRequest(id);

            return executeRequest<Artist>(request);
        }
#endif

        private RestRequest createArtistSearchRequest(ArtistSearchOptions options)
        {
            var request = new RestRequest();
            request.Resource = "search/artists";

            if (!string.IsNullOrEmpty(options.Name))
                request.AddParameter("artistName", options.Name);

            if (options.Page.HasValue)
                request.AddParameter("p", options.Page);

            return request;
        }

        private RestRequest createArtistIdRequest(string id)
        {
            var request = new RestRequest();
            request.Resource = "artist/" + id;

            return request;
        }
    }
}
