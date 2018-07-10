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

    public GameObject FreeMode;
    public GameObject Gauntlet;
    public GameObject Back;

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

    public void OpenPlay()
    {
        FreeMode.SetActive(true);
        Gauntlet.SetActive(true);
        Back.SetActive(true);

        Disclaimer.SetActive(false);
        Play.SetActive(false);
        Settings.SetActive(false);
        credits.SetActive(false);
        HighScores.SetActive(false);
    }

    public void ClosePlay()
    {
        FreeMode.SetActive(false);
        Gauntlet.SetActive(false);
        Back.SetActive(false);

        Disclaimer.SetActive(true);
        credits.SetActive(true);
        Play.SetActive(true);
        Settings.SetActive(true);
        HighScores.SetActive(true);
    }
}
