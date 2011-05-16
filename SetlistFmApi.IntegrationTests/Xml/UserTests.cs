using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using SetlistFmApi.SearchOptions.Users;

namespace SetlistFmApi.IntegrationTests.Xml
{
    public class UserTests : IntegrationTestBase
    {
        [Fact]
        public void FindUser_ById_CanFindUser()
        {
            string id = "gshackles";

            var user = _client.FindUser(id);

            Assert.NotNull(user);
            Assert.Equal("http://www.gregshackles.com", user.Website);
            Assert.Equal("gshackles", user.UserId);
            Assert.Equal("gshackles", user.Twitter);
            Assert.Equal("demonofthefall9", user.LastFm);
            Assert.Equal("Greg Shackles", user.FullName);
            Assert.Contains("beer", user.About);
        }

        [Fact]
        public void FindUserAttended_CanFindSetlists()
        {
            var options = new UserAttendedSearchOptions() { UserId = "fuzy" };

            var results = _client.FindUserAttended(options);

            Assert.NotNull(results);
            Assert.NotEmpty(results.Setlists);
        }

        [Fact]
        public void FindUserEdited_CanFindSetlists()
        {
            var options = new UserEditedSearchOptions() { UserId = "fuzy" };

            var results = _client.FindUserEdited(options);

            Assert.NotNull(results);
            Assert.NotEmpty(results.Setlists);
        }
    }
}
