using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersionLoader : MonoBehaviour
{
    public Text versionText;
    public string versionPrefix;

	// Use this for initialization
	void Start ()
    {
        versionText.text = versionPrefix + " " + VersionCheck.verNum;
	}
}
