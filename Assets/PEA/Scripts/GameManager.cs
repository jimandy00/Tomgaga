using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Puzzle1 puzzle1;
    public Puzzle2 puzzle2;
    public AudioClip puzzleClearAudioClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    private void Start()
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.PlayBGM(SoundManager.BGM.PlayTheme);
        }
    }

    public void PuzzleClear()
    {
        if(SoundManager.instance != null)
        {
            SoundManager.instance.PlaySFX(puzzleClearAudioClip);
            SoundManager.instance.PlayBGM(SoundManager.BGM.PlayTheme);
        }
    }

    // 플레이어 리스폰 될 때 퍼즐, 트랩 리셋.
    public void PuzzlesReset()
    {
        print("reset puzzle");
        if (!puzzle1.IsCoimpleted)
        {
            print("1");
            puzzle1.ResetPuzzle();
        }
        else if (!puzzle2.IsCompleted)
        {
            print("2");
            puzzle2.ResetPuzzle();
        }

        if (SoundManager.instance != null)
        {
            SoundManager.instance.PlayBGM(SoundManager.BGM.Puzzle);
        }
    }
}
