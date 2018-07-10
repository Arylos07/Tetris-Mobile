using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerStart;
    public float timer;
    public Text timerText;
    public Image timerBar;
    public AudioClip gameOver;
    public AudioSource SFX;
    public bool runTimer = false;
    public AudioSource musicSource;

    // Use this for initialization
    void Start ()
    {
        timer = timerStart;
	}

    // Update is called once per frame
    void Update()
    {
        if(runTimer == true)
        {
            if (UIControl.canDrop == true)
            {
                timer -= Time.deltaTime;
                timerText.text = ":" + timer.ToString("F0");
                timerBar.fillAmount = timer / timerStart;

                musicSource.pitch = Mathf.Lerp(1.0f, 1.6f, (Mathf.Abs(timer - timerStart) /200));

                if (timer > (timerStart / 2))
                {
                    timerBar.color = new Color((1.0f - (timer / timerStart)) * 2.0f, 1, 0);
                }
                else if (timer < (timerStart / 2))
                {
                    timerBar.color = new Color(1, (timer / timerStart) * 2.0f, 0);
                }


                if (timer <= 0)
                {
                    UIControl.canDrop = false;
                    timer = 0;
                    Spawner.GameOver();
                    SFX.PlayOneShot(gameOver);
                }
            }
        }
	}
}
