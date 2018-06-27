using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePreview : MonoBehaviour
{
    public GameObject[] pieces;

    public void UpdatePreview(int i)
    {
        foreach(GameObject go in pieces)
        {
            go.SetActive(false);
        }

        pieces[i].SetActive(true);
    }
}
