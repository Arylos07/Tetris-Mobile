using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    // Time since last gravity tick
    float lastFall = 0;
    public static float fallTick;
    public string groupName;
    public int scoreStage;
    [HideInInspector] public bool hardDrop = false;
    public Sprite[] sprite;
    public SpriteRenderer[] blocks;
    public AudioClip drop;
    public AudioClip gameOver;
    private AudioSource SFX;

    private void OnDisable()
    {
        SFX.PlayOneShot(drop);
    }

    void Start()
    {
        SFX = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        fallTick = Settings.speed;
        // Default position not valid? Then it's game over
        if (!IsValidGridPos())
        {
            Spawner.GameOver();
            SFX.PlayOneShot(gameOver);
            Destroy(gameObject);
        }

        UpdateColour(Settings.levelNum);
    }

    public void UpdateColour(int colourNum)
    {
        foreach (SpriteRenderer block in blocks)
        {
            if (block != null)
            {
                block.sprite = sprite[colourNum];
            }
        }
    }

    public bool IsValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = BoxGrid.RoundVec2(child.position);

            // Not inside Border?
            if (!BoxGrid.InsideBorder(v))
                return false;

            // Block in grid cell (and not part of same group)?
            if (BoxGrid.grid[(int)v.x, (int)v.y] != null &&
                BoxGrid.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }

    public void UpdateGrid()
    {
        // Remove old children from grid
        for (int y = 0; y < BoxGrid.h; ++y)
            for (int x = 0; x < BoxGrid.w; ++x)
                if (BoxGrid.grid[x, y] != null)
                    if (BoxGrid.grid[x, y].parent == transform)
                        BoxGrid.grid[x, y] = null;

        // Add new children to grid
        foreach (Transform child in transform)
        {
            Vector2 v = BoxGrid.RoundVec2(child.position);
            BoxGrid.grid[(int)v.x, (int)v.y] = child;
        }
    }

    private void Update()
    {
        // Move Left
        if (Input.GetButtonDown("Left") && UIControl.canDrop == true)
        {
            // Modify position
            transform.position += new Vector3(-1, 0, 0);

            // See if valid
            if (IsValidGridPos())
                // Its valid. Update grid.
                UpdateGrid();
            else
                // Its not valid. revert.
                transform.position += new Vector3(1, 0, 0);
        }
        // Move Right
        else if (Input.GetButtonDown("Right") && UIControl.canDrop == true)
        {
            // Modify position
            transform.position += new Vector3(1, 0, 0);

            // See if valid
            if (IsValidGridPos())
                // It's valid. Update grid.
                UpdateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(-1, 0, 0);
        }
        // Rotate
        else if (Input.GetButtonDown("Rotate") && groupName.ToLower() != "o" && UIControl.canDrop == true)
        {
            transform.Rotate(0, 0, -90);

            // See if valid
            if (IsValidGridPos())
                // It's valid. Update grid.
                UpdateGrid();
            else
                // It's not valid. revert.
                transform.Rotate(0, 0, 90);
        }
        else if (Input.GetButtonDown("Fall") && UIControl.canDrop == true)
        {
            Scoring.score++;

            // Modify position
            transform.position += new Vector3(0, -1, 0);

            // See if valid
            if (IsValidGridPos())
            {
                // It's valid. Update grid.
                UpdateGrid();
            }
            else
            {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);

                // Clear filled horizontal lines
                BoxGrid.DeleteFullRows();

                // Disable script
                enabled = false;

                // Spawn next Group
                FindObjectOfType<Spawner>().SpawnNext();
            }
            Scoring.UpdateUI();
        }
        // Move Downwards and Fall
        else if (UIControl.canDrop == true && Time.time - lastFall >= fallTick)
        {
            // Modify position
            transform.position += new Vector3(0, -1, 0);

            // See if valid
            if (IsValidGridPos())
            {
                // It's valid. Update grid.
                UpdateGrid();
            }
            else
            {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);

                // Clear filled horizontal lines
                BoxGrid.DeleteFullRows();

                // Disable script
                enabled = false;

                // Spawn next Group
                FindObjectOfType<Spawner>().SpawnNext();

            }

            lastFall = Time.time;
        }
        // Move Downwards and Fall
        else if (Input.GetButton("Hard Drop") || hardDrop == true)
        {
            if (UIControl.canDrop == true)
            {
                // Modify position
                transform.position += new Vector3(0, -1, 0);
                Scoring.score++;

                // See if valid
                if (IsValidGridPos())
                {
                    // It's valid. Update grid.
                    UpdateGrid();
                }
                else
                {
                    // It's not valid. revert.
                    transform.position += new Vector3(0, 1, 0);

                    // Clear filled horizontal lines
                    BoxGrid.DeleteFullRows();

                    // Disable script
                    enabled = false;
                    Scoring.UpdateUI();

                    // Spawn next Group
                    FindObjectOfType<Spawner>().SpawnNext();
                }
            }
        }
    }
}
