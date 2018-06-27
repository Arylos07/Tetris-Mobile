using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSpeed : MonoBehaviour
{
    public Text speedText;
    public Slider input;
    public GameObject warning;

    public void Awake()
    {
        input.value = (Settings.speedMult * 2);
        speedText.text = Settings.speedMult.ToString("F1");

        if (Settings.speed > 1.0f)
        {
            warning.SetActive(true);
        }
        else if (Settings.speed <= 1.0f)
        {
            warning.SetActive(false);
        }
    }

    public void UpdateSpeed()
    {
        Settings.speedMult = ((float)input.value / 2.0f);
        speedText.text = Settings.speedMult.ToString("F1");

        Scoring.UpdateSpeed();

        if(Settings.speed > 1.0f)
        {
            warning.SetActive(true);
        }
        else if(Settings.speed <= 1.0f)
        {
            warning.SetActive(false);
        }
    }
}
