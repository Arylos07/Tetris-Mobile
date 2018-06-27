using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject curtain;
    public GameObject header;
    public GameObject borders;
    public GameObject preview;

    public void Restart()
    {
        StartCoroutine(ResetRun());
    }
	
    public void LoadScene(string sceneName)
    {
        StartCoroutine(BeginLoad(sceneName));
    }

    public IEnumerator ResetRun()
    {
        header.SetActive(false);
        curtain.SetActive(true);
        borders.SetActive(false);
        preview.SetActive(false);
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator BeginLoad(string sceneName)
    {
        if (preview != null)
            preview.SetActive(false);

        header.SetActive(false);
        curtain.SetActive(true);
        borders.SetActive(false);
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneName);
    }
}
