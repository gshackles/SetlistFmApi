using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.Model.Users;
using RestSharp;
using SetlistFmApi.SearchOptions.Users;
using SetlistFmApi.SearchResults.Music;

namespace SetlistFmApi
{
    public partial class SetlistFmApi
    {
#if (!__ANDROID__ && !SILVERLIGHT && !WINDOWS_PHONE)
        public User FindUser(string userId)
        {
            var request = createUserIdRequest(userId);

            return executeRequest<User>(request);
        }

        public SetlistSearchResult FindUserAttended(UserAttendedSearchOptions options)
        {
            var request = createUserAttendedRequest(options);

            return executeRequest<SetlistSearchResult>(request);
        }

        public SetlistSearchResult FindUserEdited(UserEditedSearchOptions options)
        {
            var request = createUserEditedRequest(options);

            return executeRequest<SetlistSearchResult>(request);
        }
#endif

        private RestRequest createUserIdRequest(string userId)
        {
            var request = new RestRequest();
            request.Resource = "user/{UserId}";

            request.AddUrlSegment("UserId", userId);

            return request;
        }

        private RestRequest createUserAttendedRequest(UserAttendedSearchOptions options)
        {
            var request = new RestRequest();
            request.Resource = "user/{UserId}/attended";

            request.AddUrlSegment("UserId", options.UserId);

            if (options.Page.HasValue)
                request.AddParameter("p", options.Page.Value);

            return request;
        }

        private RestRequest createUserEditedRequest(UserEditedSearchOptions options)
        {
            var request = new RestRequest();
            request.Resource = "user/{UserId}/edited";

            request.AddUrlSegment("UserId", options.UserId);

            if (options.Page.HasValue)
                request.AddParameter("p", options.Page.Value);

            return request;
        }
    }
}
