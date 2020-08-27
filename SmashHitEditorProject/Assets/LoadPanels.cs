using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPanels : MonoBehaviour
{
    public RectTransform panelA;
    public RectTransform panelB;
    public RectTransform pointA;
    public RectTransform pointB;
    public RectTransform pointC;
    public RectTransform pointD;


    public bool open = true;

    private void Update()
    {
        if (open == true)
        {
            panelB.transform.position = Vector3.MoveTowards(panelB.transform.position, new Vector3(panelB.transform.position.x, pointC.transform.position.y, panelB.transform.position.z), 1024 * Time.deltaTime);
            panelA.transform.position = Vector3.MoveTowards(panelA.transform.position, new Vector3(panelA.transform.position.x, pointA.transform.position.y, panelA.transform.position.z), 1024 * Time.deltaTime);
        }
        else if (open == false)
        {
            panelB.transform.position = Vector3.MoveTowards(panelB.transform.position, new Vector3(panelB.transform.position.x, pointD.transform.position.y, panelB.transform.position.z), 1024 * Time.deltaTime);
            panelA.transform.position = Vector3.MoveTowards(panelA.transform.position, new Vector3(panelA.transform.position.x, pointB.transform.position.y, panelA.transform.position.z), 1024 * Time.deltaTime);
        }
    }
}
