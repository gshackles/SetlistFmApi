using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetlistFmApi.IntegrationTests
{
    public abstract class IntegrationTestBase
    {
        protected SetlistFmApi _client;

        public IntegrationTestBase()
        {
            _client = new SetlistFmApi(null);
        }
    }
}
