using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Deserializers;
using SetlistFmApi.Model;
using SetlistFmApi.Model.Music;
using SetlistFmApi.SearchResults.Music;
using Xunit;
using RestSharp;

namespace SetlistFmApi.Tests.Deserialization.Xml
{
    public class MusicDeserializationTests : MusicDeserializationTestsBase
    {
        public override DataFormat Format
        {
            get { return DataFormat.Xml; }
        }
    }
}
