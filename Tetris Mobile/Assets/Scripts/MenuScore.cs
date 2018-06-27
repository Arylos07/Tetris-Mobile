using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScore : MonoBehaviour
{
    public Text TopScore;
    public Text TopScoreName;

	// Use this for initialization
	void Start ()
    {
        TopScore.text = SaveLoad.topScore.ToString();

        if(TopScoreName != null)
            TopScoreName.text = SaveLoad.topName;
	}
	
}
