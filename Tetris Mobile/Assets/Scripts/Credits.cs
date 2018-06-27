using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject Play;
    public GameObject Settings;
    public GameObject credits;
    public GameObject creditsText;
    public GameObject Disclaimer;
    public GameObject HighScores;

    public void OpenCredits()
    {
        Disclaimer.SetActive(false);
        Play.SetActive(false);
        Settings.SetActive(false);
        credits.SetActive(false);
        creditsText.SetActive(true);
        HighScores.SetActive(false);
    }

    public void CloseCredits()
    {
        Disclaimer.SetActive(true);
        creditsText.SetActive(false);
        credits.SetActive(true);
        Play.SetActive(true);
        Settings.SetActive(true);
        HighScores.SetActive(true);
    }
}
