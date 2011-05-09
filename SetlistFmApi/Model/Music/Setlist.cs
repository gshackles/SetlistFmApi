using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.Model.Location;

namespace SetlistFmApi.Model.Music
{
    public class Setlist
    {
        public string VersionId { get; set; }

        public string Tour { get; set; }

        public string Id { get; set; }

        public string LastFmEventId { get; set; }

        public DateTime EventDate { get; set; }

        public Artist Artist { get; set; }

        public Venue Venue { get; set; }

        public List<Set> Sets { get; set; }
    }
}
