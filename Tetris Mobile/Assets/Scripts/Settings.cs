using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static float musicVolume;
    public static float sfxVolume;
    public static bool oneHand;
    public static float speed = 0.5f;
    [HideInInspector] public GameObject[] bricks;
    public ControlModes modes;
    public static List<float> speeds = (new List<float>{0.799f, 0.715f, 0.632f, 0.549f, 0.466f, 0.383f, 0.300f, 0.216f, 0.133f, 0.100f, 0.083f, 0.083f, 0.083f, 0.067f, 0.067f, 0.067f, 0.050f, 0.050f, 0.050f, 0.033f, 0.017f});
    public static float speedMult;
    public static int levelNum = 0;    //for assigning colours only!!!

    public void Init()
    {
        if (speedMult == 0)
            speedMult = 1;

        levelNum = 0;

        speed = (speeds[0] * speedMult);
    }

    public void Init(float reduce)
    {
        if (speedMult == 0)
            speedMult = 1;

        levelNum = 0;

        int i = 0;
        foreach (float speed in speeds)
        {
            speeds[i] = speeds[i] * reduce;

            i++;
        }

        speed = (speeds[0] * speedMult);
    }

    public void ResetSpeed(float reduce)
    {
        int i = 0;
        foreach (float speed in speeds)
        {
            speeds[i] = speeds[i] / reduce;

            i++;
        }
    }

    public static void ChangeSpeed(int index)
    {
        speed = (speeds[index] * speedMult);
    }

    public void SettingsPanel()
    {
        if (gameObject.activeSelf == false)
        {
            bricks = GameObject.FindGameObjectsWithTag("Group");

            foreach (GameObject brick in bricks)
            {
                brick.SetActive(false);
            }
            gameObject.SetActive(true);
        }
        else if(gameObject.activeSelf == true)
        {
            foreach (GameObject brick in bricks)
            {
                brick.SetActive(true);
            }
            gameObject.SetActive(false);
            SaveLoad.SaveConfig();
        }
    }

    public static void IncreaseColour()
    {
        levelNum++;
        if (levelNum > 9)
            levelNum = 0;

        GameObject[] go = GameObject.FindGameObjectsWithTag("Group");

        foreach (GameObject brick in go)
        {
            brick.GetComponent<Group>().UpdateColour(levelNum);
        }

    }

    public void MenuSettingsPanel()
    {
        if(gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }
        else if(gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
            SaveLoad.SaveConfig();
        }
    }
	
    public void ControlMode()
    {
        if(oneHand == false)
        {
            if (modes != null)
            {
                modes.OneHand();
            }
            else
            {
                oneHand = true;
            }
        }
        else if(oneHand == true)
        {
            if (modes != null)
            {
                modes.TwoHand();
            }
            else
            {
                oneHand = false;
            }
        }
    }
}
