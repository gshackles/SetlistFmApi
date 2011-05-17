using System;
using System.IO;
using System.Xml.Linq;
using RestSharp;
using RestSharp.Deserializers;
using SetlistFmApi.Deserialization;
using SetlistFmApi.Deserialization.Xml;
using SetlistFmApi.Deserialization.Json;

namespace SetlistFmApi.Tests.Deserialization
{
    public abstract class DeserializationTestBase
    {
        private readonly string _sampleDataPath = Path.Combine(Environment.CurrentDirectory, "Deserialization\\SampleData");

        public abstract DataFormat Format { get; }

        protected T deserializeFromFile<T>(string filename) where T : new()
        {
            var deserializer = getDeserializer(filename);
            string filePath = getSampleDataFilePath(filename);
            var doc = File.ReadAllText(filePath);
            var response = new RestResponse() { Content = doc.ToString() };
            
            return deserializer.Deserialize<T>(response);
        }

        private string getSampleDataFilePath(string filename)
        {
            string type = Format == DataFormat.Json ? "json" : "xml";

            return Path.Combine(
                    Path.Combine(_sampleDataPath, type), 
                    string.Format("{0}.{1}", filename, type));
        }

        private IDeserializer getDeserializer(string filename)
        {
            if (Format == DataFormat.Json)
                return new SetlistFmJsonDeserializer();

            return new SetlistFmXmlDeserializer();
        }
    }
}
