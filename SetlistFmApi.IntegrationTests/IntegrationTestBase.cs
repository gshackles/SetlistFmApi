using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace SetlistFmApi.IntegrationTests
{
    public abstract class IntegrationTestBase
    {
        protected SetlistFmApi _client;

        public abstract DataFormat Format { get; }

        public IntegrationTestBase()
        {
            _client = new SetlistFmApi(null);
            _client.Format = Format;
        }
    }
}
