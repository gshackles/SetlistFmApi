using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.Model.Users;
using SetlistFmApi.SearchResults.Music;
using SetlistFmApi.SearchOptions.Users;

namespace SetlistFmApi
{
    public partial class SetlistFmApi
    {
        public void FindUserAsync(string userId, Action<User> callback)
        {
            var request = createUserIdRequest(userId);

            executeRequestAsync<User>(request, callback);
        }

        public void FindUserAttended(UserAttendedSearchOptions options, Action<SetlistSearchResult> callback)
        {
            var request = createUserAttendedRequest(options);

            executeRequestAsync<SetlistSearchResult>(request, callback);
        }

        public void FindUserEditedAsync(UserEditedSearchOptions options, Action<SetlistSearchResult> callback)
        {
            var request = createUserEditedRequest(options);

            executeRequestAsync<SetlistSearchResult>(request, callback);
        }
    }
}
