using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.SearchOptions.Music;
using Xunit;

namespace SetlistFmApi.Tests
{
    public class MusicTests : SetlistFmApiTestBase
    {
        [Fact]
        public void FindArtists_ByName_CanFindArtist()
        {
            var options = new ArtistSearchOptions {Name = "Opeth"};

            var results = _client.FindArtists(options);

            Assert.Equal("Opeth", results.Artists.First().Name);
        }

        [Fact]
        public void FindArtist_ById_CanFindArtist()
        {
            var id = "c14b4180-dc87-481e-b17a-64e4150f90f6";

            var artist = _client.FindArtist(id);

            Assert.Equal("Opeth", artist.Name);
        }
    }
}
