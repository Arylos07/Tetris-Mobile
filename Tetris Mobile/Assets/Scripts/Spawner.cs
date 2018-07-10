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
    public bool isGauntlet = false;
    public float reduce;
    public Timer timer;

    private void Start()
    {
        Init();
        if (isGauntlet)
        {
            settings.Init(reduce);
        }
        else
        {
            settings.Init();
        }
        StartCoroutine(Countdown());
    }

    public static void GameOver()
    {
        Spawner spawnerObject = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();

        spawnerObject.StartCoroutine(spawnerObject.DestroyGroups(GameObject.FindGameObjectsWithTag("Block")));
    }

    public IEnumerator DestroyGroups(GameObject[] objects)
    {
        if(timer != null)
        {
            timer.runTimer = false;
        }

        foreach(GameObject obj in objects)
        {
            yield return new WaitForSeconds(0.025f);
            Destroy(obj);
        }

        if (isGauntlet == false)
        {
            Scoring.GameOver();
        }
        else if(isGauntlet == true)
        {
            timer.runTimer = false;
            settings.ResetSpeed(reduce);
            Scoring.GauntletOver();
        }
    }

    public void SpawnNext()
    {
        DisableDrop(); //disable the last block
        obj = Instantiate(groups[spawn], transform.position, Quaternion.identity); //spawn the next block
        obj.GetComponent<Group>().hardDrop = false; //allow block to fall normally

        n++;    //counter to determine block

        //n means the number of spawns, used to determine frequency of certain block spawns

        if (n >= Random.Range(4, 12)) //if counter is greater than or equal to a random number between 4-12
            //the higher the counter (the more spawns), the more likely that it will spawn an i piece.
        {
            i = 0; //manually spawn the i piece (line)
            n = 0; //reset counter
        }
        else //if it does not match the number
        {
            i = Random.Range(0, groups.Length); //roll for the 7 pieces plus an 8th "reroll"
            if (i == groups.Length)
            {
                i = Random.Range(0, groups.Length - 1); // if reroll is selected, roll again, but without the reroll. (creates randomness)
            }
        }

        if(i >= 4 && n >= 6) //if it has been a while since the last i piece
        {
            i = Random.Range(0, 3); //spawn I, L, or J pieces by default.
        }

        spawn = i; //the block to be spawned when this function is called
        SetControls(obj); //tell controls to use this block
        preview.UpdatePreview(i); //Show preview of next piece
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
        UIControl.canDrop = true;
        if (isGauntlet)
        {
            timer.runTimer = true;
        }
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
