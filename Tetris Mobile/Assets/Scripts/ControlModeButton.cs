using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlModeButton : MonoBehaviour
{
    public Text modeText;

	// Update is called once per frame
	void Update ()
    {
		if(Settings.oneHand == true)
        {
            modeText.text = "One Hand";
        }
        else if(Settings.oneHand == false)
        {
            modeText.text = "Two Hand";
        }
	}
}
