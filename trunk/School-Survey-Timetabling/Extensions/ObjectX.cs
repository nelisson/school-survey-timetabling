using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Extensions
{
    public static class ObjectX
    {
        public static string Serialize<T>(this T _object)
        {
            var xmlSettings = new XmlWriterSettings
                                  {OmitXmlDeclaration = true, Indent = true, NewLineOnAttributes = true};

            var serializer = new XmlSerializer(_object.GetType());

            var stringBuilder = new StringBuilder();

            using (var writer = XmlWriter.Create(stringBuilder, xmlSettings))
                serializer.Serialize(writer, _object);

            return stringBuilder.ToString();
        }
    }
}