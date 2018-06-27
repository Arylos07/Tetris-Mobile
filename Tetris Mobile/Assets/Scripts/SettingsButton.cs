using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [HideInInspector] public Button self;
    public Sprite settingsSprite;
    public Sprite closeSprite;
    public GameObject settingsPanel;

    void Start()
    {
        self = gameObject.GetComponent<Button>();
    }

    public void Toggle()
    {
        if (settingsPanel.activeSelf == true)
        {
            self.image.sprite = closeSprite;
        }
        else if (settingsPanel.activeSelf == false)
        {
            self.image.sprite = settingsSprite;
            self.interactable = false;
        }
    }

    public void UpdateButton()
    {
        self.interactable = true;
    }
}
