using RestSharp;

namespace SetlistFmApi.Deserialization.CustomDeserializers
{
    public interface ICustomXmlDeserializer
    {
        object Deserialize(RestResponse response);
    }
}
