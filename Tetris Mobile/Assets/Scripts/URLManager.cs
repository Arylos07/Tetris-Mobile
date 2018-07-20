using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLManager : MonoBehaviour
{
    public static string versionURL;

    public void Support()
    {
        Application.OpenURL("https://templariusgames.com/support");
    }

    public void GitHub()
    {
        //put latest Github release here
        Application.OpenURL("https://github.com/Arylos07/Tetris-Mobile/releases/tag/v" + versionURL);
    }
}
