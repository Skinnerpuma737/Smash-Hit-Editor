using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigMenu : MonoBehaviour
{
    public InputField x;
    public InputField y;
    public InputField z;

    public segmentconfig config;
    public Button startButton;
    private void Update()
    {
        if (x.text == "" || y.text == "" || z.text == "")
        {
            startButton.interactable = false;
        }
        else if (float.Parse(x.text) <= 0 || float.Parse(y.text) <= 0 || float.Parse(z.text) <= 0)
        {
            startButton.interactable = false;
        }
        else
        {
            startButton.interactable = true;
            config.size = new Vector3(float.Parse(x.text), float.Parse(y.text), float.Parse(z.text));
        }
    }
}
