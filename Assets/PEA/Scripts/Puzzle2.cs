using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    public static Puzzle2 instance = null;

    private bool isComplete = false;

    public Puzzle2_Mural[] murals;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CheckIsComplete()
    {
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
}
