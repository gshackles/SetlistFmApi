using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetlistFmApi.Tests
{
    public abstract class SetlistFmApiTestBase
    {
        protected SetlistFmApi _client;

        public SetlistFmApiTestBase()
        {
            _client = new SetlistFmApi("");
        }
    }
}
