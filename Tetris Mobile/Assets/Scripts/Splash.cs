using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public GameObject curtain;

    private void Start()
    {
        StartCoroutine(SplashScreen());
        SaveLoad.LoadConfig();
        SaveLoad.Load();
    }

    public IEnumerator SplashScreen()
    {
        yield return new WaitForSeconds(1);
        curtain.SetActive(false);

        yield return new WaitForSeconds(6);
        curtain.SetActive(true);

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }
}
