using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Group target;
    public static bool canDrop = false;
    public AudioClip move;
    public AudioClip rotate;
    public AudioSource sfxSource;

    public void UIInput(string control)
    {
        if (target != null)
        {
            // Move Left
            if (control == "Left" && canDrop == true)
            {
                // Modify position
                target.transform.position += new Vector3(-1, 0, 0);

                sfxSource.PlayOneShot(move);

                // See if valid
                if (target.IsValidGridPos())
                    // Its valid. Update grid.
                    target.UpdateGrid();
                else
                    // Its not valid. revert.
                    target.transform.position += new Vector3(1, 0, 0);
            }
            // Move Right
            else if (control == "Right" && canDrop == true)
            {
                // Modify position
                target.transform.position += new Vector3(1, 0, 0);

                sfxSource.PlayOneShot(move);

                // See if valid
                if (target.IsValidGridPos())
                    // It's valid. Update grid.
                    target.UpdateGrid();
                else
                    // It's not valid. revert.
                    target.transform.position += new Vector3(-1, 0, 0);
            }
            // Rotate
            else if (control == "Rotate" && target.groupName.ToLower() != "o" && canDrop == true)
            {
                sfxSource.PlayOneShot(rotate);

                target.transform.Rotate(0, 0, -90);

                // See if valid
                if (target.IsValidGridPos())
                    // It's valid. Update grid.
                    target.UpdateGrid();
                else
                    // It's not valid. revert.
                    target.transform.Rotate(0, 0, 90);
            }
            else if (control == "Soft Drop")
            {
                if (canDrop == true)
                {
                    Scoring.score++;

                    // Modify position
                    target.transform.position += new Vector3(0, -1, 0);

                    // See if valid
                    if (target.IsValidGridPos())
                    {
                        // It's valid. Update grid.
                        target.UpdateGrid();
                    }
                    else
                    {
                        // It's not valid. revert.
                        target.transform.position += new Vector3(0, 1, 0);

                        // Clear filled horizontal lines
                        BoxGrid.DeleteFullRows();

                        // Disable script
                        target.enabled = false;

                        // Spawn next Group
                        FindObjectOfType<Spawner>().SpawnNext();
                    }
                    Scoring.UpdateUI();
                }
            }
            else if(control == "Hard Drop" && canDrop == true)
            {
                target.hardDrop = true;
            }
        }
    }
}
