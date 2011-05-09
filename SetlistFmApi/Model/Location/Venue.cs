using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetlistFmApi.Model.Location
{
    public class Venue
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public City City { get; set; }
    }
}
