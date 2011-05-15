using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using SetlistFmApi.Model.Users;

namespace SetlistFmApi.Tests.Deserialization
{
    public class UserDeserializationTests : DeserializationTestBase
    {
        [Fact]
        public void Can_Deserialize_User()
        {
            var user = deserializeFromFile<User>("user_gshackles.xml");

            Assert.Equal("http://www.gregshackles.com", user.Website);
            Assert.Equal("gshackles", user.UserId);
            Assert.Equal("gshackles", user.Twitter);
            Assert.Equal("demonofthefall9", user.LastFm);
            Assert.Equal("Greg Shackles", user.FullName);
            Assert.Contains("beer", user.About);
        }
    }
}
