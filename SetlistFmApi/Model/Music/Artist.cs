using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Serializers;
using RestSharp.Deserializers;

namespace SetlistFmApi.Model.Music
{
    public class Artist
    {
        public string MbId { get; set; }

        public string Name { get; set; }

        public string SortName { get; set; }
    }
}
