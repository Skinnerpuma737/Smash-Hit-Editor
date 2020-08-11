using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public Segment seg;

    private void Save()
    {
        
        XML.ConvertToXML(seg, seg.Name + ".xml");
    }
}
