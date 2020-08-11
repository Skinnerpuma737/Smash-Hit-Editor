using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

public class Data : MonoBehaviour
{
    [XmlElement("Segment")]
    public Segment seg;

    
    public void Save()
    {
        
        XML.ConvertToXML(seg, seg.Name + ".xml");
    }
}
