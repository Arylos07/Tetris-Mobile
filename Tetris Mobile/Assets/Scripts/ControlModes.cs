using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlModes : MonoBehaviour
{
    public GameObject oneHandParent;
    public GameObject twoHandParent;
    public UIControl[] oneHand;
    public UIControl[] twoHands;
    public Spawner spawner;

    private void Start()
    {
        int i = 0;
        //Does not need reference to spawner.obj because the spawner has not created an instance at the start of the game, but will set instance when it is spawned
        if (Settings.oneHand == true)
        {
            twoHandParent.SetActive(false);
            oneHandParent.SetActive(true);
            foreach (UIControl c in oneHand)
            {
                spawner.controls[i] = c;
                i++;
            }
        }
        else if (Settings.oneHand == false)
        {
            twoHandParent.SetActive(true);
            oneHandParent.SetActive(false);
            foreach (UIControl c in twoHands)
            {
                spawner.controls[i] = c;
                i++;
            }
        }
    }

    public void OneHand()
    {
        twoHandParent.SetActive(false);
        oneHandParent.SetActive(true);
        int i = 0;

        Settings.oneHand = true;

        foreach (UIControl cc in oneHand)
        {
            spawner.controls[i] = cc;
            cc.target = spawner.obj.GetComponent<Group>();
            i++;
        }
    }

    public void TwoHand()
    {
        twoHandParent.SetActive(true);
        oneHandParent.SetActive(false);
        int i = 0;

        Settings.oneHand = false;

        foreach (UIControl cc in twoHands)
        {
            spawner.controls[i] = cc;
            cc.target = spawner.obj.GetComponent<Group>();
            i++;
        }
    }
}
