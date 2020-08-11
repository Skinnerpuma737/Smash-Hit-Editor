using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

public class XML
{
    public static void ConvertToXML(object item, string path)
    {
        XmlSerializer serializer = new XmlSerializer(item.GetType());
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("", "");

        XmlWriterSettings settings = new XmlWriterSettings();
        settings.OmitXmlDeclaration = true;
        settings.Indent = true;

        var stream = new FileStream(path, FileMode.Create);
        var writer = XmlWriter.Create(stream, settings);
        serializer.Serialize(writer, item, ns);
        stream.Close();
    }
}
