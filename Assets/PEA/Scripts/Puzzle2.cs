using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    public static Puzzle2 instance = null;

    private bool isTrapStart = false;
    private bool isCompleted = false;

    public Puzzle2_Mural[] murals;
    public Trap2 trap2;

    public Dialogue firstStoneDialogue;
    public Dialogue clearDialogue;
    public Dialogue failDialogue;

    public bool IsCompleted
    {
        get { return isCompleted; }
    }

    private void Awake()
    {
        instance = this;
    }

    public void CheckIsComplete()
    {
        if (!isTrapStart)
        {
            isTrapStart = true;
            trap2.enabled = true;
        }
        foreach (Puzzle2_Mural mural in murals)
        {
            if (mural.HasStone)
            {
                firstStoneDialogue.ShowDialogue();
                print(isCompleted);
                return;
            }
        }

        isCompleted = true;
        print(isCompleted);
    }

    public void ResetPuzzle()
    {
        isTrapStart = false;
        foreach(Puzzle2_Mural mural in murals)
        {
            mural.ResetMural();
        }
        trap2.ResetTrap();
    }
}
