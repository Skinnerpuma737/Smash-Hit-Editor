using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMenu : MonoBehaviour
{
    public GameObject UI;
    public InputField segName;
    public Button button;
    public segmentconfig config;
    private void Update()
    {
        if (segName.text == "")
        {
            button.interactable = false;
        }
        else if (segName.text != "")
        {
            config.Name = segName.text;
            button.interactable = true;
        }

        
    }
    
}
