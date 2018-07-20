using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] music;
    public static int trackID;
    public AudioSource musicSource;

    public Text musicText;

	// Use this for initialization
	void Start ()
    {
        musicSource.clip = music[trackID];
        musicSource.Play();

        if (musicText != null)
            musicText.text = musicSource.clip.name;
    }
	
    public void UpdateMusic(int id)
    {
        trackID = id;

        musicSource.clip = music[trackID];
        musicSource.Play();

        if (musicText != null)
            musicText.text = musicSource.clip.name;

        SaveLoad.SaveConfig();
    }

    public void NextSong()
    {
        if((trackID + 1) > (music.Length - 1))
        {
            UpdateMusic(0);
        }
        else
        {
            UpdateMusic(trackID + 1);
        }
    }
}
