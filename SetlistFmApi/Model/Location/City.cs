using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetlistFmApi.Model.Location
{
    public class City
    {
        public string StateCode { get; set; }

        public string State { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public Coordinates Coords { get; set; }

        public Country Country { get; set; }
    }
}
