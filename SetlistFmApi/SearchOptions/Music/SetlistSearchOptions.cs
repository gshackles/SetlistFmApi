using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetlistFmApi.SearchOptions.Music
{
    public class SetlistSearchOptions : ListOptionsBase
    {
        public string ArtistMbId { get; set; }

        public string ArtistName { get; set; }

        public string Tour { get; set; }

        public DateTime? Date { get; set; }

        public int? Year { get; set; }

        public string VenueId { get; set; }

        public string VenueName { get; set; }

        public string CityId { get; set; }

        public string CityName { get; set; }

        public string StateCode { get; set; }

        public string State { get; set; }

        public string CountryCode { get; set; }

        public string LanguageCode { get; set; }
    }
}
