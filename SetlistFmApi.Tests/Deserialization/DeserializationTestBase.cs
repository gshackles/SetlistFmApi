using System;
using System.IO;
using System.Xml.Linq;
using RestSharp;
using RestSharp.Deserializers;
using SetlistFmApi.Deserialization;
using SetlistFmApi.Deserialization.Xml;

namespace SetlistFmApi.Tests.Deserialization
{
    public abstract class DeserializationTestBase
    {
        private readonly string _sampleDataPath = Path.Combine(Environment.CurrentDirectory, "Deserialization\\SampleData");
        
        protected T deserializeFromFile<T>(string filename) where T : new()
        {
            var deserializer = getDeserializer(filename);
            string path = Path.Combine(getSampleDataFolder(filename), filename);
            var doc = File.ReadAllText(path);
            var response = new RestResponse() { Content = doc.ToString() };
            
            return deserializer.Deserialize<T>(response);
        }

        private string getSampleDataFolder(string filename)
        {
            return Path.Combine(_sampleDataPath, filename.EndsWith(".json") ? "Json" : "Xml");
        }

        private IDeserializer getDeserializer(string filename)
        {
            if (filename.EndsWith(".json"))
                throw new NotImplementedException("JSON not supported yet");
                //return new JsonDeserializer();

            return new SetlistFmXmlDeserializer();
        }
    }
}
