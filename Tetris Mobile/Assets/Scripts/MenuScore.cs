using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScore : MonoBehaviour
{
    public Text TopScore;
    public Text TopScoreName;
    public bool isGauntlet = false;

	// Use this for initialization
	void Start ()
    {
        if (isGauntlet == true)
        {
            TopScore.text = SaveLoad.gtopScore.ToString();

            if (TopScoreName != null)
                TopScoreName.text = SaveLoad.topName;
        }

        else if (isGauntlet == false)
        {
            TopScore.text = SaveLoad.topScore.ToString();

            if (TopScoreName != null)
                TopScoreName.text = SaveLoad.topName;
        }
    }
	
}
