using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segmentconfig : MonoBehaviour
{
    public Vector3 size;
    public string Name;
    Data d;
    private void Start()
    {
        d = FindObjectOfType<Data>();
    }
    private void Update()
    {
        #region stop negative size
        if (size.x < 0)
        {
            size = new Vector3(1, size.y, size.z);
        }
        if (size.y < 0)
        {
            size = new Vector3(size.x, 1, size.z);
        }
        if (size.z < 0)
        {
            size = new Vector3(size.x, size.y, 1);
        }
        #endregion
        d.seg.Name = Name;
        

        d.seg.s = size;
    }

}
