using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public static int score = 0;
    private static int scoreStage = 0;
    public static int level = 0;
    public int lines = 0;
    public Text scoreText;
    public Text levelText;
    public Text linesText;
    public static Scoring self;
    public static int levelNum = 0;
    public SceneLoader sceneLoader;
    public Animator background;

    public AudioSource sfxSource;
    public AudioClip scoreSFX;
    public AudioClip tetris;
    public AudioClip levelUp;

    // Use this for initialization
    void Start ()
    {
        score = 0;
        level = 0;
        lines = 0;
        levelNum = 0;
        self = gameObject.GetComponent<Scoring>();

        scoreText.text = score.ToString();
        levelText.text = level.ToString();
        linesText.text = lines.ToString();
	}

    public static void GameOver()
    {
        if(score >= SaveLoad.score3)
        {
            if(score >= SaveLoad.score2)
            {
                if(score >= SaveLoad.topScore)
                {
                    SaveLoad.name3 = SaveLoad.name2;
                    SaveLoad.score3 = SaveLoad.score2;
                    SaveLoad.level3 = SaveLoad.level2;

                    SaveLoad.name2 = SaveLoad.topName;
                    SaveLoad.score2 = SaveLoad.topScore;
                    SaveLoad.level2 = SaveLoad.topLevel;

                    SaveLoad.topName = "--------";
                    SaveLoad.topScore = score;
                    SaveLoad.topLevel = level;
                }
                else
                {
                    SaveLoad.name3 = SaveLoad.name2;
                    SaveLoad.score3 = SaveLoad.score2;
                    SaveLoad.level3 = SaveLoad.level2;

                    SaveLoad.name2 = "--------";
                    SaveLoad.score2 = score;
                }
            }
            else
            {
                SaveLoad.name3 = "--------";
                SaveLoad.score3 = score;
            }
            HighScoresLoader.fromGame = true;
            GameObject.FindGameObjectWithTag("Scoring").GetComponent<Scoring>().sceneLoader.LoadScene("TopScores");
        }
        else
        {
            GameObject.FindGameObjectWithTag("Scoring").GetComponent<Scoring>().sceneLoader.LoadScene("MainMenu");
        }
    }

    public static void UpdateUI()
    {
        self.scoreText.text = score.ToString();
        self.linesText.text = self.lines.ToString();
        level = self.lines / 10;
        self.levelText.text = level.ToString();
    }

    public static void CalculateScore(int i)
    {
        if(i == 1)
        {
            scoreStage = (40 * (level + 1));
            BoxGrid.rowsCleared = 0;
            self.sfxSource.PlayOneShot(self.scoreSFX);
        }
        else if(i == 2)
        {
            scoreStage = (100 * (level + 1));
            BoxGrid.rowsCleared = 0;
            self.sfxSource.PlayOneShot(self.scoreSFX);
        }

        else if(i == 3)
        {
            scoreStage = (300 * (level + 1));
            BoxGrid.rowsCleared = 0;
            self.sfxSource.PlayOneShot(self.scoreSFX);
        }
        else if(i == 4)
        {
            self.background.ResetTrigger("Tetris");
            scoreStage = (1200 * (level + 1));
            BoxGrid.rowsCleared = 0;
            self.sfxSource.PlayOneShot(self.tetris);
            self.background.SetTrigger("Tetris");
        }
        else
        {
            print("invalid input; i = " + i);
        }

        if(Settings.speed > 1.0f)
        {
            scoreStage = (Mathf.RoundToInt(scoreStage / Settings.speed));
        }


        score += scoreStage;
        self.scoreText.text = score.ToString();
        self.lines += i;
        self.linesText.text = self.lines.ToString();
        level = self.lines / 10;
        self.levelText.text = level.ToString();

        if (level > levelNum)
        {
            self.sfxSource.PlayOneShot(self.levelUp);
            levelNum = level;
            Settings.IncreaseColour();

            if (level <= 19)
            {
                Settings.ChangeSpeed(level);
            }
            else if (level > 19 && level <= 28)
            {
                Settings.ChangeSpeed(19);
            }
            else if (level >= 29)
            {
                Settings.ChangeSpeed(20);
            }
        }
    }

    public static void UpdateSpeed()
    {
        if (level <= 19)
        {
            Settings.ChangeSpeed(level);
        }
        else if (level > 19 && level <= 28)
        {
            Settings.ChangeSpeed(19);
        }
        else if (level >= 29)
        {
            Settings.ChangeSpeed(20);
        }
    }
}
