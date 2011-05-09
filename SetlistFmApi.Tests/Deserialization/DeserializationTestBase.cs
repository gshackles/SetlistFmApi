using System;
using System.IO;
using System.Xml.Linq;
using RestSharp;
using RestSharp.Deserializers;

namespace SetlistFmApi.Tests.Deserialization
{
    public abstract class DeserializationTestBase
    {
        private string _sampleDataPath = Path.Combine(Environment.CurrentDirectory, "Deserialization\\Xml");
        
        protected T deserializeFromFile<T>(string filename) where T : new()
        {
            var deserializer = new XmlDeserializer()
                                   {
                                       DateFormat = "dd-MM-yyyy"
                                   };
            string path = Path.Combine(_sampleDataPath, filename);
            var doc = XDocument.Load(path);
            var response = new RestResponse()
                                {
                                    Content = doc.ToString()
                                };
            
            return deserializer.Deserialize<T>(response);
        }
    }
}
