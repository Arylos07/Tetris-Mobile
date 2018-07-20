using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteNotice : MonoBehaviour
{
    public GameObject saveNotice;
    public GameObject configNotice;
    public GameObject settingsPanel;
    public Credits creditsManager;

	public void DeleteConfig()
    {
        creditsManager.ToggleMenu(false);
        settingsPanel.SetActive(false);
        configNotice.SetActive(true);
    }
	
    public void DeleteSave()
    {
        creditsManager.ToggleMenu(false);
        settingsPanel.SetActive(false);
        saveNotice.SetActive(true);
    }

    public void Confirm(string file)
    {
        if(file.ToLower() == "config")
        {
            SaveLoad.DeleteConfig();
        }
        else if(file.ToLower() == "save")
        {
            SaveLoad.Delete();
        }
    }

    public void CancelDelete()
    {
        creditsManager.ToggleMenu(true);
        configNotice.SetActive(false);
        saveNotice.SetActive(false);
        settingsPanel.SetActive(true);
    }
}
