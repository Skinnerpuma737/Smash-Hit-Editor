using System;
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
        /*This function saves to .xml*/

        
        #region format segment size
        /*This formats the segment size to a string in the smash hit size format*/
        string sx, sy, sz;
        if (seg.s.x == Mathf.RoundToInt(seg.s.x))
        {
            sx = seg.s.x + ".0";
        }
        else
        {
            sx = seg.s.x + "";
        }
        if (seg.s.y == Mathf.RoundToInt(seg.s.y))
        {
            sy = seg.s.y + ".0";
        }
        else
        {
            sy = seg.s.y + "";
        }
        if (seg.s.z == Mathf.RoundToInt(seg.s.z))
        {
            sz = seg.s.z + ".0";
        }
        else
        {
            sz = seg.s.z + "";
        }
        seg.size = sx + " " + sy + " " + sz;
        #endregion
        foreach (Box b in seg.box)
        {
            /*This loop loops over the box array in seg and formats the size and position of each box
             we do this to make it easier to work with the size and position of the boxs while in the
             editor*/
            string x;
            string y;
            string z;
            #region formatsize
            if (b.s.x == Mathf.RoundToInt(b.s.x)) {
                x = b.s.x + ".0";
            }
            else
            {
                x = b.s.x + "";
            }
            if (b.s.y == Mathf.RoundToInt(b.s.y))
            {
                y = b.s.y + ".0";
            }
            else
            {
                y = b.s.y + "";
            }
            if (b.s.z == Mathf.RoundToInt(b.s.z))
            {
                z = b.s.z + ".0";
            }
            else
            {
                z = b.s.z + "";
            }
            #endregion
            b.size = x + " " + y + " " + z;
            x = "";
            y = "";
            z = "";
            #region formatpos
            if (b.p.x == Mathf.RoundToInt(b.p.x))
            {
                x = b.p.x + ".0";
            }
            else
            {
                x = b.p.x + "";
            }
            if (b.p.y == Mathf.RoundToInt(b.p.y))
            {
                y = b.p.y + ".0";
            }
            else
            {
                y = b.p.y + "";
            }
            if (b.p.z == Mathf.RoundToInt(b.p.z))
            {
                z = b.p.z + ".0";
            }
            else
            {
                z = b.p.z + "";
            }
            #endregion
            b.pos = x + " " + y + " " + z;
            
        }
        /*Convert to xml*/
        XML.ConvertToXML(seg, seg.Name + ".xml");
    }
}
