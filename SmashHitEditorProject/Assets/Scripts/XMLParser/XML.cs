using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
public class XML
{
    public static void ConvertToXML(object item, string path)
    {
        XmlSerializer serializer = new XmlSerializer(item.GetType());
        var stream = new FileStream(path, FileMode.Create);
        serializer.Serialize(stream, item);
        stream.Close();
    }
}
