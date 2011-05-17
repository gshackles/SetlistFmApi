using System.IO;
using System.Text;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace SetlistFmApi.Deserialization.Json
{
    public class BadgerFisher
    {
        public string JsonToXml(string json)
        {
            var jsonObject = JObject.Parse(json);
            var xmlBuilder = new StringBuilder();

            using (var xmlWriter = XmlWriter.Create(xmlBuilder))
            {
                processObject(jsonObject, xmlWriter);
            }

            return xmlBuilder.ToString();
        }

        private void processObject(JObject obj, XmlWriter xmlWriter)
        {
            foreach (var prop in obj)
            {
                if (prop.Value.Type == JTokenType.Object)
                {
                    xmlWriter.WriteStartElement(prop.Key);
                    processObject((JObject)prop.Value, xmlWriter);
                    xmlWriter.WriteEndElement();
                }
                else if (prop.Value.Type == JTokenType.String)
                {
                    processString(prop.Key, prop.Value.ToString(), xmlWriter);
                }
                else if (prop.Value.Type == JTokenType.Array)
                {
                    processArray(prop.Key, (JArray)prop.Value, xmlWriter);
                }
            }
        }

        private void processString(string key, string value, XmlWriter xmlWriter)
        {
            if (key.StartsWith("@"))
            {
                xmlWriter.WriteAttributeString(key.Substring(1), value);
            }
            else if (key == "$")
            {
                xmlWriter.WriteValue(value);
            }
            else
            {
                xmlWriter.WriteElementString(key, value);
            }
        }

        private void processArray(string elementName, JArray array, XmlWriter xmlWriter)
        {
            foreach (var element in array)
            {
                xmlWriter.WriteStartElement(elementName);

                if (element.Type == JTokenType.Object)
                {
                    processObject((JObject)element, xmlWriter);
                }

                xmlWriter.WriteEndElement();
            }
        }
    }
}
