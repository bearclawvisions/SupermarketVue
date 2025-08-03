using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Supermarket.Domain.Extensions;

public static class XmlExtensions
{
    /// <summary>
    /// Serializes an object to XML string
    /// </summary>
    /// <typeparam name="T">Type of object to serialize</typeparam>
    /// <param name="obj">Object to serialize</param>
    /// <param name="omitXmlDeclaration">Whether to omit XML declaration</param>
    /// <param name="indent">Whether to format with indentation</param>
    /// <returns>XML string representation</returns>
    public static string ToXml<T>(this T obj, bool omitXmlDeclaration = true, bool indent = true) where T : class
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        var serializer = new XmlSerializer(typeof(T));
        var settings = new XmlWriterSettings
        {
            OmitXmlDeclaration = omitXmlDeclaration,
            Indent = indent,
            Encoding = Encoding.UTF8
        };

        using var stringWriter = new StringWriter();
        using var xmlWriter = XmlWriter.Create(stringWriter, settings);

        // Create empty namespaces to avoid xmlns attributes if desired
        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add("", "");

        serializer.Serialize(xmlWriter, obj, namespaces);
        return stringWriter.ToString();
    }

    /// <summary>
    /// Deserializes XML string to object of type T
    /// </summary>
    /// <typeparam name="T">Type to deserialize to</typeparam>
    /// <param name="xmlString">XML string to deserialize</param>
    /// <returns>Deserialized object</returns>
    public static T FromXml<T>(this string xmlString) where T : class
    {
        if (string.IsNullOrWhiteSpace(xmlString))
            throw new ArgumentException("XML string cannot be null or empty", nameof(xmlString));

        var serializer = new XmlSerializer(typeof(T));
        using var stringReader = new StringReader(xmlString);
        using var xmlReader = XmlReader.Create(stringReader);

        var result = serializer.Deserialize(xmlReader) as T;
        return result ?? throw new InvalidOperationException($"Failed to deserialize XML to type {typeof(T).Name}");
    }
}