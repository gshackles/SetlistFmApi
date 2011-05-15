using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetlistFmApi.SearchOptions.Music
{
    public class SetlistByTourSearchOptions : ListOptionsBase
    {
        public string MbId { get; set; }

        public string Tour { get; set; }
    }
}
