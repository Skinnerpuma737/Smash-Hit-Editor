using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public class Box
{
    [XmlIgnore]
    public GameObject visual;


    [XmlAttribute("Size")]
    public string size;
    

}
