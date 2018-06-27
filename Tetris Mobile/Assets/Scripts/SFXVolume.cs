using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXVolume : MonoBehaviour
{
    public AudioSource self;
    public Slider volumeSlider;
    public AudioClip select;

	// Use this for initialization
	void Start ()
    {
        self.volume = Settings.sfxVolume;

        if(volumeSlider != null)
            volumeSlider.value = Settings.sfxVolume;
	}

    public void UpdateVolume()
    {
        Settings.sfxVolume = volumeSlider.value;
        self.volume = Settings.sfxVolume;
    }
    
    public void ButtonEffect()
    {
        self.PlayOneShot(select);
    }

}
