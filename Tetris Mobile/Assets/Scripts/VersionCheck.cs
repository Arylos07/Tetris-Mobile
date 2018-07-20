using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VersionCheck : MonoBehaviour
{
    //update this value with each update
    public static string verNum = "1.5.1";

    public Text loadingText;
    public GameObject updateButton;

    private string versionCheckURL = "https://tetris.templariusgames.com/GameReqs/version.php";

    // Use this for initialization
    void Start()
    {
        StartCoroutine(CheckServerStatus());
    }

    public void OnApplicationPause(bool pause)
    {
        if(pause == false)
        {
            StartCoroutine(CheckServerStatus());
        }
    }

    IEnumerator CheckServerStatus()
    {
        updateButton.SetActive(false);
        loadingText.text = "Communicating with servers...";
        WWW online = new WWW(versionCheckURL);
        yield return new WaitForSeconds(1);
        yield return online;

        if (online.text == string.Empty || !string.IsNullOrEmpty(online.error))
        {
            loadingText.text = "An unknown error was encountered in checking build version. This is not a major issue.\nPlease check your internet settings or check status.templariusgames.com \nerror: " + online.error;
        }

        else if (online.text != string.Empty || string.IsNullOrEmpty(online.error))
        {
            if (online.text != verNum)
            {
                loadingText.text = "An update is available for download!\nIf you would like to update, press the button below for the latest release!";
                URLManager.versionURL = online.text;
                updateButton.SetActive(true);
            }
            else
            {
                loadingText.text = string.Empty;
            }
        }
    }
}
