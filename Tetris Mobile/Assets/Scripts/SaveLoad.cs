using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public static string topName;
    public static int topScore;
    public static int topLevel;

    public static string name2;
    public static int score2;
    public static int level2;

    public static string name3;
    public static int score3;
    public static int level3;

    public static string gtopName;
    public static int gtopScore;
    public static int gtopLevel;

    public static string gname2;
    public static int gscore2;
    public static int glevel2;

    public static string gname3;
    public static int gscore3;
    public static int glevel3;

    void Start()
    {
        //Stream the manager so it can be called at any point in the game to save any variables.
        DontDestroyOnLoad(gameObject);
    }

    //On method call SaveLoad.Save()
    public static void Save()
    {
        //Load binary coding and create a file to write to.
        BinaryFormatter binary = new BinaryFormatter();
        FileStream fStream = File.Create(Application.persistentDataPath + "/data.sav");

        //Create a copy of the SaveManager to get variables to save.
        SaveManager saver = new SaveManager();
        saver.topName = topName;
        saver.topScore = topScore;
        saver.topLevel = topLevel;

        saver.name2 = name2;
        saver.score2 = score2;
        saver.level2 = level2;

        saver.name3 = name3;
        saver.score3 = score3;
        saver.level3 = level3;

        saver.gtopName = gtopName;
        saver.gtopScore = gtopScore;
        saver.gtopLevel = gtopLevel;

        saver.gname2 = gname2;
        saver.gscore2 = gscore2;
        saver.glevel2 = glevel2;

        saver.gname3 = gname3;
        saver.gscore3 = gscore3;
        saver.glevel3 = glevel3;
        //Add other variables if needed...

        //Encrypt information
        binary.Serialize(fStream, saver);
        //Close file.
        fStream.Close();
        Load();
    }

    public static void SaveConfig()
    {
        //Load binary coding and create a file to write to.
        BinaryFormatter binary = new BinaryFormatter();
        FileStream fStream = File.Create(Application.persistentDataPath + "/config.conf");

        //Create a copy of the SaveManager to get variables to save.
        ConfigManager config = new ConfigManager();
        config.speedMult = Settings.speedMult;
        config.MusicVolume = Settings.musicVolume;
        config.SFXVolume = Settings.sfxVolume;
        config.oneHand = Settings.oneHand;
        config.musicID = MusicManager.trackID;
        //Add other variables if needed...

        //Encrypt information
        binary.Serialize(fStream, config);
        //Close file.
        fStream.Close();
    }

    public static void LoadConfig()
    {
        //Only load if there is an existing file.
        if (File.Exists(Application.persistentDataPath + "/config.conf"))
        {
            //Load binary formatter and open the file. Decrypt the file and close it.
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/config.conf", FileMode.Open);
            ConfigManager config = (ConfigManager)binary.Deserialize(fStream);
            fStream.Close();

            //Take decrypted variables and add them to the GameController so rules can be adjusted accordingly.
            Settings.speedMult = config.speedMult;
            Settings.musicVolume = config.MusicVolume;
            Settings.sfxVolume = config.SFXVolume;
            Settings.oneHand = config.oneHand;
            MusicManager.trackID = config.musicID;
            //Add other variables if needed...
        }
        else
        {
            Settings.speedMult = 1.0f;
            Settings.musicVolume = 1.0f;
            Settings.sfxVolume = 1.0f;
            Settings.oneHand = false;
            MusicManager.trackID = 0;

            SaveConfig();
        }
    }

        //On method call SaveLoad.Load()
        public static void Load()
    {
        //Only load if there is an existing file.
        if (File.Exists(Application.persistentDataPath + "/data.sav"))
        {
            //Load binary formatter and open the file. Decrypt the file and close it.
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/data.sav", FileMode.Open);
            SaveManager saver = (SaveManager)binary.Deserialize(fStream);
            fStream.Close();

            //Take decrypted variables and add them to the GameController so rules can be adjusted accordingly.
            topName = saver.topName;
            topScore = saver.topScore;
            topLevel = saver.topLevel;

            name2 = saver.name2;
            score2 = saver.score2;
            level2 = saver.level2;

            name3 = saver.name3;
            score3 = saver.score3;
            level3 = saver.level3;

            gtopName = saver.gtopName;
            gtopScore = saver.gtopScore;
            gtopLevel = saver.gtopLevel;

            gname2 = saver.gname2;
            gscore2 = saver.gscore2;
            glevel2 = saver.glevel2;

            gname3 = saver.gname3;
            gscore3 = saver.gscore3;
            glevel3 = saver.glevel3;

            //Add other variables if needed...
            if(gtopScore == 0)
            {
                gtopName = "Alexey";
                gtopScore = 2000;
                gtopLevel = 4;

                gname2 = "Howard";
                gscore2 = 1000;
                glevel2 = 3;

                gname3 = "Otasan";
                gscore3 = 800;
                glevel3 = 2;

                Save();
            }

        }
        else
        {
            topName = "Alexey";
            topScore = 20000;
            topLevel = 9;

            name2 = "Howard";
            score2 = 10000;
            level2 = 9;

            name3 = "Otasan";
            score3 = 7500;
            level3 = 5;

            gtopName = "Alexey";
            gtopScore = 2000;
            gtopLevel = 4;

            gname2 = "Howard";
            gscore2 = 1000;
            glevel2 = 3;

            gname3 = "Otasan";
            gscore3 = 800;
            glevel3 = 2;

            Save();
        }
    }

    public static void Delete()
    {
        if (File.Exists(Application.persistentDataPath + "/data.sav"))
        {
            File.Delete(Application.persistentDataPath + "/data.sav");
            //File.Delete(Application.persistentDataPath + "/savegameAUTO.save");
            SceneManager.LoadScene("Splash");
        }
    }

    public static void DeleteConfig()
    {
        if (File.Exists(Application.persistentDataPath + "/config.conf"))
        {
            File.Delete(Application.persistentDataPath + "/config.conf");
            SceneManager.LoadScene("Splash");
        }
    }
}

//Can be serialized
[Serializable]

//Object that records all information to be saved.
class SaveManager
{
    public string topName;
    public int topScore;
    public int topLevel;

    public string name2;
    public int score2;
    public int level2;

    public string name3;
    public int score3;
    public int level3;

    public string gtopName;
    public int gtopScore;
    public int gtopLevel;

    public string gname2;
    public int gscore2;
    public int glevel2;

    public string gname3;
    public int gscore3;
    public int glevel3;
    //Add other variaables if needed...
}

//Can be serialized
[Serializable]

//Object that records configuration information
class ConfigManager
{
    public float speedMult;
    public float MusicVolume;
    public float SFXVolume;
    public int musicID;
    public bool oneHand;
    //Add other variaables if needed...
}