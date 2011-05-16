using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using SetlistFmApi.SearchResults.Location;
using SetlistFmApi.Deserialization.Xml.CustomDeserializers;

namespace SetlistFmApi.Deserialization.Xml
{
    public class SetlistFmXmlDeserializer : IDeserializer
    {
        private XmlDeserializer _deserializer;
        private Dictionary<Type, ICustomXmlDeserializer> _customDeserializers;

        public SetlistFmXmlDeserializer()
        {
            _deserializer = new XmlDeserializer();
            _deserializer.DateFormat = "dd-MM-yyyy";

            _customDeserializers = new Dictionary<Type, ICustomXmlDeserializer>()
            {
                { typeof(CitySearchResult), new CitySearchResultXmlDeserializer() }
            };
        }

        public T Deserialize<T>(RestResponse response) where T : new()
        {
            var type = typeof(T);

            if (_customDeserializers.ContainsKey(type))
            {
                return (T)_customDeserializers[type].Deserialize(response);
            }

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