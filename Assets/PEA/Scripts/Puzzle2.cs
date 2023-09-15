using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    public static Puzzle2 instance = null;

    private bool isTrapStart = false;
    private bool isComplete = false;

    public Puzzle2_Mural[] murals;
    public Trap2 trap2;

    public bool IsComplete
    {
        get { return isComplete; }
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
                print(isComplete);
                return;
            }
        }

        isComplete = true;
        print(isComplete);
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
