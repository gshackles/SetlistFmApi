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
            var setlist = deserializeFromFile<Setlist>("setlist_metallica.xml");

            Assert.NotNull(setlist);
            Assert.Equal("73dc6219", setlist.VersionId);
            Assert.Equal("World Magnetic", setlist.Tour);
            Assert.Equal("3bd6440c", setlist.Id);
            Assert.Equal(new DateTime(2009, 7, 25), setlist.EventDate);
            Assert.Equal("Metallica", setlist.Artist.Name);
            Assert.Equal("Sonisphere Festival", setlist.Venue.Name);
            Assert.Equal(2, setlist.Sets.Count);

            var set = setlist.Sets.First();

            Assert.Equal(16, set.Songs.Count);

            var coverSong = set.Songs.ElementAt(0);
            Assert.Equal("The Ecstasy of Gold", coverSong.Name);
            Assert.NotNull(coverSong.Cover);
            Assert.Equal("Ennio Morricone", coverSong.Cover.Name);

            var encore = setlist.Sets.ElementAt(1);

            Assert.Equal(3, encore.Songs.Count);
            Assert.True(encore.Encore);
        }

        [Fact]
        public void Can_Deserialize_Setlist_Search_Results()
        {
            var results = deserializeFromFile<SetlistSearchResult>("setlist_list.xml");

            Assert.NotNull(results);
            Assert.Equal(20, results.Setlists.Count);

            var setlist = results.Setlists.First();

            Assert.Equal("Sounds of The Summer", setlist.Tour);
            Assert.Equal(new DateTime(2010, 8, 27), setlist.EventDate);
        }
    }
}
