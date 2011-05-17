using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.SearchOptions.Music;
using Xunit;

namespace SetlistFmApi.IntegrationTests
{
    public abstract class MusicTestsBase : IntegrationTestBase
    {
        [Fact]
        public void FindArtists_ByName_CanFindArtist()
        {
            var options = new ArtistSearchOptions { Name = "Opeth" };

            var results = _client.FindArtists(options);

            Assert.Equal("Opeth", results.Artists.First().Name);
        }

        [Fact]
        public void FindArtist_ById_CanFindArtist()
        {
            string id = "c14b4180-dc87-481e-b17a-64e4150f90f6";

            var artist = _client.FindArtist(id);

            Assert.Equal("Opeth", artist.Name);
        }

        [Fact]
        public void FindSetlists_ByArtistStateAndYear_CanFindSetlists()
        {
            var options = new SetlistSearchOptions() { Year = 2010, 
                                                       ArtistName = "Opeth", 
                                                       StateCode = "NY" };

            var results = _client.FindSetlists(options);

            Assert.NotNull(results);
            Assert.NotEmpty(results.Setlists);
            Assert.Equal("Opeth", results.Setlists.First().Artist.Name);
            Assert.Equal(new DateTime(2010, 4, 7), results.Setlists.First().EventDate);
        }

        [Fact]
        public void FindSetlists_ByArtist_CanFindSetlists()
        {
            var options = new SetlistByArtistSearchOptions() { MbId = "c14b4180-dc87-481e-b17a-64e4150f90f6" };

            var results = _client.FindSetlistsByArtist(options);

            Assert.NotNull(results);
            Assert.NotEmpty(results.Setlists);
            Assert.Equal("Opeth", results.Setlists.First().Artist.Name);
        }

        [Fact]
        public void FindSetlist_ById_CanFindSetlist()
        {
            string id = "3bd6440c";

            var setlist = _client.FindSetlist(id);

            Assert.NotNull(setlist);
            Assert.Equal("Metallica", setlist.Artist.Name);
        }

        [Fact]
        public void FindSetlist_ByLastFmEvent_CanFindSetlist()
        {
            string id = "999009";

            var setlist = _client.FindSetlistByLastFmEvent(id);

            Assert.NotNull(setlist);
            Assert.Equal("Metallica", setlist.Artist.Name);
        }

        [Fact]
        public void FindSetlist_ByVersion_CanFindSetlist()
        {
            string id = "6bd45a36";

            var setlist = _client.FindSetlistByVersion(id);

            Assert.NotNull(setlist);
            Assert.Equal("Metallica", setlist.Artist.Name);
        }

        [Fact]
        public void FindSetlistsByTour_CanFindSetlists()
        {
            var options = new SetlistByTourSearchOptions() { MbId = "65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab", 
                                                             Tour = "World Magnetic" };

            var results = _client.FindSetlistsByTour(options);

            Assert.NotNull(results);
            Assert.NotEmpty(results.Setlists);
        }
    }
}
