using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using SetlistFmApi.Model.Users;
using RestSharp;

namespace SetlistFmApi.Tests.Deserialization.Xml
{
    public class UserDeserializationTests : UserDeserializationTestsBase
    {
        public override DataFormat Format
        {
            get { return DataFormat.Xml; }
        }
    }
}
