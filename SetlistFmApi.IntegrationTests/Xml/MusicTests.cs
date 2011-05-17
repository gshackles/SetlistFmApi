using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.SearchOptions.Music;
using Xunit;
using RestSharp;

namespace SetlistFmApi.IntegrationTests.Xml
{
    public class MusicTests : MusicTestsBase
    {
        public override DataFormat Format
        {
            get { return DataFormat.Xml; }
        }
    }
}
