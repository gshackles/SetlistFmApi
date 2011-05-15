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

        public SetlistSearchResult FindSetlists(SetlistSearchOptions options)
        {
            var request = createSetlistSearchRequest(options);

            return executeRequest<SetlistSearchResult>(request);
        }

        public Setlist FindSetlist(string id)
        {
            var request = createSetlistIdRequest(id);

            return executeRequest<Setlist>(request);
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

        private RestRequest createSetlistSearchRequest(SetlistSearchOptions options)
        {
            var request = new RestRequest();
            request.Resource = "search/setlists";

            if (!string.IsNullOrEmpty(options.ArtistMbId))
                request.AddParameter("artistMbid", options.ArtistMbId);

            if (!string.IsNullOrEmpty(options.ArtistName))
                request.AddParameter("artistName", options.ArtistName);

            if (!string.IsNullOrEmpty(options.Tour))
                request.AddParameter("tour", options.Tour);

            if (options.Date.HasValue)
                request.AddParameter("date", options.Date.Value.ToString("dd-MM-yyyy"));

            if (options.Year.HasValue)
                request.AddParameter("year", options.Year.Value);

            if (!string.IsNullOrEmpty(options.VenueId))
                request.AddParameter("venueId", options.VenueId);

            if (!string.IsNullOrEmpty(options.VenueName))
                request.AddParameter("venueName", options.VenueName);

            if (!string.IsNullOrEmpty(options.CityId))
                request.AddParameter("cityId", options.CityId);

            if (!string.IsNullOrEmpty(options.CityName))
                request.AddParameter("cityName", options.CityName);

            if (!string.IsNullOrEmpty(options.StateCode))
                request.AddParameter("stateCode", options.StateCode);

            if (!string.IsNullOrEmpty(options.State))
                request.AddParameter("state", options.State);

            if (!string.IsNullOrEmpty(options.CountryCode))
                request.AddParameter("countryCode", options.CountryCode);

            if (options.Page.HasValue)
                request.AddParameter("p", options.Page.Value);

            if (!string.IsNullOrEmpty(options.LanguageCode))
                request.AddParameter("l", options.LanguageCode);

            return request;
        }

        private RestRequest createSetlistIdRequest(string id)
        {
            var request = new RestRequest();
            request.Resource = "setlist/" + id;

            return request;
        }
    }
}
