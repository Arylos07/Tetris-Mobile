using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoresLoader : MonoBehaviour
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
	void Start ()
    {
        topName.text = SaveLoad.topName;
        topScore.text = SaveLoad.topScore.ToString();
        topLevel.text = SaveLoad.topLevel.ToString();

        name2.text = SaveLoad.name2;
        score2.text = SaveLoad.score2.ToString();
        level2.text = SaveLoad.level2.ToString();

        name3.text = SaveLoad.name3;
        score3.text = SaveLoad.score3.ToString();
        level3.text = SaveLoad.level3.ToString();

        if(fromGame == false)
        {
            inputField.SetActive(false);
            menuButton.SetActive(true);

            foreach(GameObject text in texts)
            {
                text.SetActive(false);
            }

            HighScoresText.SetActive(true);
        }
	}

    public void UpdateScores()
    {
        if(SaveLoad.topName == "--------")
        {
            SaveLoad.topName = nameInput.text;
        }
        else if(SaveLoad.name2 == "--------")
        {
            SaveLoad.name2 = nameInput.text;
        }
        else if(SaveLoad.name3 == "--------")
        {
            SaveLoad.name3 = nameInput.text;
        }

        SaveLoad.Save();

        //update names
        topName.text = SaveLoad.topName;
        name2.text = SaveLoad.name2;
        name3.text = SaveLoad.name3;

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
