using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.SearchOptions.Location;
using Xunit;
using RestSharp;

namespace SetlistFmApi.IntegrationTests.Json
{
    public class LocationTests : LocationTestsBase
    {
        public override DataFormat Format
        {
            get { return DataFormat.Json; }
        }
    }
}
