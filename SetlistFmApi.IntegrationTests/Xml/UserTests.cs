using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using SetlistFmApi.SearchOptions.Users;
using RestSharp;

namespace SetlistFmApi.IntegrationTests.Xml
{
    public class UserTests : UserTestsBase
    {
        public override DataFormat Format
        {
            get { return DataFormat.Xml; }
        }
    }
}
