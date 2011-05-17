using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Deserializers;
using SetlistFmApi.Deserialization.Xml;
using RestSharp;

namespace SetlistFmApi.Deserialization.Json
{
    public class SetlistFmJsonDeserializer : IDeserializer
    {
        private SetlistFmXmlDeserializer _deserializer;
        private BadgerFisher _badgerFisher;

        public SetlistFmJsonDeserializer()
        {
            _badgerFisher = new BadgerFisher();
            _deserializer = new SetlistFmXmlDeserializer();
        }

        public T Deserialize<T>(RestResponse response) where T : new()
        {
            response.Content = _badgerFisher.JsonToXml(response.Content);

            return _deserializer.Deserialize<T>(response);
        }

        public string DateFormat
        {
            get { return _deserializer.DateFormat; }
            set { _deserializer.DateFormat = value; }
        }

        
        public string Namespace
        {
            get { return _deserializer.Namespace; }
            set { _deserializer.Namespace = value; }
        }

        public string RootElement
        {
            get { return _deserializer.RootElement; }
            set { _deserializer.RootElement = value; }
        }
    }
}
