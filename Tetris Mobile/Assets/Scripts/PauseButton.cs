using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [HideInInspector] public Button self;
    public Sprite pauseSprite;
    public Sprite unPauseSprite;
    public GameObject settingsPanel;
    public Button SettingsButton;

	// Use this for initialization
	void Start ()
    {
        self = gameObject.GetComponent<Button>();
	}

    public void TogglePause()
    {
        if(UIControl.canDrop == true)
        {
            self.image.sprite = unPauseSprite;
            SettingsButton.interactable = false;
        }
        else if(UIControl.canDrop == false)
        {
            self.interactable = false;
            if(settingsPanel.activeSelf == true)
            {
                settingsPanel.GetComponent<Settings>().SettingsPanel();
            }
        }
    }

    public void UpdateButton()
    {
        self.image.sprite = pauseSprite;
        self.interactable = true;
    }
}
