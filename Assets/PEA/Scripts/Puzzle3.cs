using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    public static Puzzle3 instance = null;

    private bool isAnswer = false;

    private List<Hole> holes = new List<Hole>();

    public AudioSource audioSource;
    public AudioClip rightHoleAudioClip;
    public AudioClip wrongHoleAudioClip;
    public Puzzle3_Door door;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        foreach (Transform  tr in transform)
        {
            holes.Add(tr.GetComponent<Hole>());
        }
    }

    void Update()
    {

    }

    public void CheckIsAnswer(bool isRightHole)
    {
        foreach(Hole hole in holes)
        {
            if (hole.isAnswer)
            {
                if (!hole.hasStone)
                {
                    isAnswer = false;
                    print(isAnswer);
                    PlaySoundAnswerOrNot(isRightHole);
                    return;
                }
            }
            else
            {
                if (hole.hasStone)
                {
                    isAnswer = false;
                    PlaySoundAnswerOrNot(isRightHole);
                    return;
                }
            }
        }

        isAnswer = true;
        GameManager.instance.PuzzleClear();
        door.OpenDoor();
    }

    public void PlaySoundAnswerOrNot(bool isAnswer)
    {
        SoundManagaer.instance.PlaySFX(isAnswer ? rightHoleAudioClip : wrongHoleAudioClip);
    }
}
