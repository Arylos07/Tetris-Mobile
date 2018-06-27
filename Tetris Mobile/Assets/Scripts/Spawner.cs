using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] groups;
    public int spawn;
    public PiecePreview preview;
    public Text countDown;
    public UIControl[] controls;
    [HideInInspector] public GameObject obj = null;
    public PauseButton pauseButton;
    public SettingsButton settingsButton;
    public Button HardDrop;
    public Button HardDrop2;
    public Settings settings;
    private int n = 0;
    private int i = 0;

    private void Start()
    {
        Init();
        settings.Init();
        StartCoroutine(Countdown());
    }

    public static void GameOver()
    {
        Spawner spawnerObject = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();

        spawnerObject.StartCoroutine(spawnerObject.DestroyGroups(GameObject.FindGameObjectsWithTag("Block")));
    }

    public IEnumerator DestroyGroups(GameObject[] objects)
    {
        foreach(GameObject obj in objects)
        {
            yield return new WaitForSeconds(0.025f);
            Destroy(obj);
        }

        Scoring.GameOver();
    }

    public void SpawnNext()
    {
        DisableDrop();
        obj = Instantiate(groups[spawn], transform.position, Quaternion.identity);
        obj.GetComponent<Group>().hardDrop = false;

        n++;

        if (n >= Random.Range(4, 12))
        {
            i = 0;
            n = 0;
        }
        else
        {
            i = Random.Range(0, groups.Length);
            if (i == groups.Length)
            {
                i = Random.Range(0, groups.Length - 1);
            }
        }

        if(i >= 4 && n >= 6)
        {
            i = Random.Range(0, 3);
        }
        spawn = i;
        SetControls(obj);
        preview.UpdatePreview(i);
    }

    public void PauseGame()
    {
        if(UIControl.canDrop == true)
        {
            UIControl.canDrop = false;
        }
        else if(UIControl.canDrop == false)
        {
            StartCoroutine(UnPause());
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause == true && pauseButton.settingsPanel.activeSelf == false)
        {
            UIControl.canDrop = false;
            pauseButton.self.image.sprite = pauseButton.unPauseSprite;
            countDown.text = "Press Play to Resume";
        }
    }

    public IEnumerator UnPause()
    {
        HardDrop.interactable = false;
        HardDrop2.interactable = false;
        settingsButton.self.image.sprite = settingsButton.settingsSprite;
        settingsButton.self.interactable = false;
        countDown.text = string.Empty;

        yield return new WaitForSecondsRealtime(1);
        countDown.text = "3";

        yield return new WaitForSecondsRealtime(1);
        countDown.text = "2";

        yield return new WaitForSecondsRealtime(1);
        countDown.text = "1";

        yield return new WaitForSecondsRealtime(1);
        countDown.text = "Go!";
        UIControl.canDrop = true;
        pauseButton.UpdateButton();
        settingsButton.UpdateButton();
        HardDrop.interactable = true;
        HardDrop2.interactable = true;

        yield return new WaitForSecondsRealtime(0.5f);
        countDown.text = string.Empty;
    }

    public void Init()
    {
        int i = Random.Range(0, groups.Length);
        if (i == groups.Length)
        {
            i = Random.Range(0, groups.Length - 1);
        }
        spawn = i;
        UIControl.canDrop = true;
    }

    public IEnumerator Countdown()
    {
        HardDrop.interactable = false;
        HardDrop2.interactable = false;
        settingsButton.self.interactable = false;
        yield return new WaitForSecondsRealtime(0.1f);
        pauseButton.self.interactable = false;
        yield return new WaitForSecondsRealtime(1);
        countDown.text = "3";

        yield return new WaitForSecondsRealtime(1);
        countDown.text = "2";

        yield return new WaitForSecondsRealtime(1);
        countDown.text = "1";

        yield return new WaitForSecondsRealtime(1);
        countDown.text = "Go!";
        SpawnNext();
        pauseButton.UpdateButton();
        settingsButton.UpdateButton();
        HardDrop.interactable = true;
        HardDrop2.interactable = true;

        yield return new WaitForSecondsRealtime(0.5f);
        countDown.text = string.Empty;
    }

    public void DisableDrop()
    {
        foreach(UIControl control in controls)
        {
            UIControl.canDrop = false;
        }
    }

    public void SetControls(GameObject brick)
    {
        foreach(UIControl control in controls)
        {
            control.target = brick.GetComponent<Group>();
            UIControl.canDrop = true;
        }
    }
}
