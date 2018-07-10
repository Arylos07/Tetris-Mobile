using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GauntletScoresLoader : MonoBehaviour
{
    public Text topName;
    public Text topScore;
    public Text topLevel;

    public Text name2;
    public Text score2;
    public Text level2;

    public Text name3;
    public Text score3;
    public Text level3;

    public GameObject inputField;
    public Text nameInput;
    public GameObject curtain;
    public GameObject borders;
    public GameObject menuButton;
    public GameObject[] texts;
    public GameObject HighScoresText;

    public static bool fromGame = false;

    // Use this for initialization
    void Start()
    {
        topName.text = SaveLoad.gtopName;
        topScore.text = SaveLoad.gtopScore.ToString();
        topLevel.text = SaveLoad.gtopLevel.ToString();

        name2.text = SaveLoad.gname2;
        score2.text = SaveLoad.gscore2.ToString();
        level2.text = SaveLoad.glevel2.ToString();

        name3.text = SaveLoad.gname3;
        score3.text = SaveLoad.gscore3.ToString();
        level3.text = SaveLoad.glevel3.ToString();

        if (fromGame == false)
        {
            inputField.SetActive(false);
            menuButton.SetActive(true);

            foreach (GameObject text in texts)
            {
                text.SetActive(false);
            }

            HighScoresText.SetActive(true);
        }
    }

    public void UpdateScores()
    {
        if (SaveLoad.gtopName == "--------")
        {
            SaveLoad.gtopName = nameInput.text;
        }
        else if (SaveLoad.gname2 == "--------")
        {
            SaveLoad.gname2 = nameInput.text;
        }
        else if (SaveLoad.gname3 == "--------")
        {
            SaveLoad.gname3 = nameInput.text;
        }

        SaveLoad.Save();

        //update names
        topName.text = SaveLoad.gtopName;
        name2.text = SaveLoad.gname2;
        name3.text = SaveLoad.gname3;

        inputField.SetActive(false);
        StartCoroutine(ReturnToMenu());
    }

    public IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(3);
        borders.SetActive(false);
        curtain.SetActive(true);
        fromGame = false;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }

    public void MainMenuCall()
    {
        StartCoroutine(MainMenu());
    }

    public IEnumerator MainMenu()
    {
        borders.SetActive(false);
        curtain.SetActive(true);
        fromGame = false;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }

}
