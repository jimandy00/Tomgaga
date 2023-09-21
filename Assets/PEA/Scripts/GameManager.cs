using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Puzzle1 puzzle1;
    public Puzzle2 puzzle2;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // 플레이어 리스폰 될 때 퍼즐, 트랩 리셋.
    public void PuzzlesReset()
    {
        if (!puzzle1.IsCoimpleted)
        {
            puzzle1.ResetPuzzle();
        }
        else if (!puzzle2.IsCompleted)
        {
            puzzle2.ResetPuzzle();
        }
    }
}
