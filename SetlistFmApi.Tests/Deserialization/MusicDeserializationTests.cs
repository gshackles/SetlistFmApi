using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Deserializers;
using SetlistFmApi.Model;
using SetlistFmApi.Model.Music;
using SetlistFmApi.SearchResults.Music;
using Xunit;

namespace SetlistFmApi.Tests.Deserialization
{
    public class MusicDeserializationTests : DeserializationTestBase
    {
        [Fact]
        public void Can_Deserialize_Artist_Search_Results()
        {
            var result = deserializeFromFile<ArtistSearchResult>("artist_list.xml");

            Assert.NotNull(result);
            //Assert.Equal(1, result.Total);
            //Assert.Equal(1, result.Page);
            //Assert.Equal(30, result.ItemsPerPage);
            Assert.Equal(2, result.Artists.Count);

            var artist = result.Artists.First();

            Assert.Equal("Opeth", artist.Name);
            Assert.Equal("Opeth", artist.SortName);
            Assert.Equal("c14b4180-dc87-481e-b17a-64e4150f90f6", artist.MbId);
        }

        [Fact]
        public void Can_Deserialize_Artist()
        {
            var artist = deserializeFromFile<Artist>("artist_opeth.xml");

            Assert.NotNull(artist);
            Assert.Equal("Opeth", artist.Name);
            Assert.Equal("Opeth", artist.SortName);
            Assert.Equal("c14b4180-dc87-481e-b17a-64e4150f90f6", artist.MbId);
        }

        [Fact]
        public void Can_Deserialize_Setlist()
        {
            var setlist = deserializeFromFile<Setlist>("setlist_opeth.xml");

            Assert.NotNull(setlist);
            Assert.Equal("1bdf21a4", setlist.VersionId);
            Assert.Equal("Evolution XX", setlist.Tour);
            Assert.Equal("6bd48ebe", setlist.Id);
            Assert.Equal("1322608", setlist.LastFmEventId);
            Assert.Equal(new DateTime(2010, 4, 7), setlist.EventDate);
            Assert.Equal("Opeth", setlist.Artist.Name);
            Assert.Equal("Terminal 5", setlist.Venue.Name);
            Assert.Equal(1, setlist.Sets.Count);

            var set = setlist.Sets.First();

            Assert.Equal(17, set.Songs.Count);

            var coverSong = set.Songs.ElementAt(8);
            Assert.Equal("Through Pain to Heaven", coverSong.Name);
            Assert.NotNull(coverSong.Cover);
            Assert.Equal("Popol Vuh", coverSong.Cover.Name);
        }

        [Fact]
        public void Can_Deserialize_Setlist_Search_Results()
        {
            var results = deserializeFromFile<SetlistSearchResult>("setlist_list.xml");

            Assert.NotNull(results);
            Assert.Equal(20, results.Setlists.Count);

            var setlist = results.Setlists.First();

            Assert.Equal("Sounds of The Summer", setlist.Tour);
        }
    }
}
