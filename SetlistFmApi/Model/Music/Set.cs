using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetlistFmApi.Model.Music
{
    public class Set
    {
        public int? Encore { get; set; }

        public List<Song> Songs { get; set; }
    }
}
