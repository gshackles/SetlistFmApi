using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetlistFmApi.Model;
using SetlistFmApi.Model.Location;
using SetlistFmApi.SearchResults.Location;
using Xunit;
using RestSharp;

namespace SetlistFmApi.Tests.Deserialization.Json
{
    public class LocationDeserializationTests : LocationDeserializationTestsBase
    {
        public override DataFormat Format
        {
            get { return DataFormat.Json; }
        }
    }
}
