using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrecisionModifier : MonoBehaviour
{
    bool modifier = false;
    public RectTransform a;
    public RectTransform b;

    public void Swap()
    {
        if (modifier == false)
        {
            modifier = true;
        }
        else if (modifier == true)
        {
            modifier = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Swap();
        }
        if (modifier == false)
        {
            a.transform.position = Vector3.MoveTowards(a.transform.position, new Vector3(430, a.transform.position.y, 0), 2);
            b.transform.position = Vector3.MoveTowards(b.transform.position, new Vector3(540, b.transform.position.y, 0), 2);
            a.GetComponent<InputField>().interactable = true;
            b.GetComponent<InputField>().interactable = false;
        }
        else if (modifier == true)
        {
            a.transform.position = Vector3.MoveTowards(a.transform.position, new Vector3(540, a.transform.position.y, 0), 2);
            b.transform.position = Vector3.MoveTowards(b.transform.position, new Vector3(430, b.transform.position.y, 0), 2);
            a.GetComponent<InputField>().interactable = false;
            b.GetComponent<InputField>().interactable = true;
        }
    }
}
