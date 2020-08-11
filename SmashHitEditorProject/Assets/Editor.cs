using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor : MonoBehaviour
{
    public GameObject grid;
    public Material gridmat;
    public segmentconfig s;

    public Vector2 gridSize;
    Material g;
    private void Start()
    {
        
        g = gridmat;
    }
    private void Update()
    {
        gridSize = new Vector2(s.size.x, s.size.z);
        grid.transform.localScale = new Vector3(gridSize.x, 0.01f, gridSize.y);
        grid.transform.position = new Vector3(0, 0, 0) + new Vector3(gridSize.x / 2,-0.5f,gridSize.y / 2);
        g.mainTextureScale = gridSize;
        grid.GetComponent<Renderer>().material = g;
        
    }
}
