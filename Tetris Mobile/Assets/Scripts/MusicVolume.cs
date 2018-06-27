using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public AudioSource self;
    public Slider volumeSlider;

    // Use this for initialization
    void Start()
    {
        self.volume = Settings.musicVolume;

        if(volumeSlider != null)
            volumeSlider.value = Settings.musicVolume;
    }

    public void UpdateVolume()
    {
        Settings.musicVolume = volumeSlider.value;
        self.volume = Settings.musicVolume;
    }
}
