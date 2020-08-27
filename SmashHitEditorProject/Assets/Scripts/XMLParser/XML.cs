using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Linq.Expressions;
using System;

public class XML
{
    public static void ConvertToXML(object item, string filename)
    {
        
        XmlSerializer serializer = new XmlSerializer(item.GetType());
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("", "");

        XmlWriterSettings settings = new XmlWriterSettings();
        settings.OmitXmlDeclaration = true;
        settings.Indent = true;
        try
        {
            if (!Directory.Exists(Application.dataPath + "/../" + "output"))
            {
                var folder = Directory.CreateDirectory(Application.dataPath + "/../" + "output");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        string path = Application.dataPath + "/../output/" + filename;
        var stream = new FileStream(path, FileMode.Create);
        var writer = XmlWriter.Create(stream, settings);
        serializer.Serialize(writer, item, ns);
        stream.Close();
    }
}
