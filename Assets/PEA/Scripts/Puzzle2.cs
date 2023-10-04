using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    public static Puzzle2 instance = null;

    private bool isTrapStart = false;
    private bool isCompleted = false;

    private AudioSource audioSource;

    public Puzzle2_Mural[] murals;
    public Trap2 trap2;

    public Dialogue firstStoneDialogue;
    public Dialogue clearDialogue;
    public Dialogue failDialogue;
    public ParticleSystem fragmentParticle;
    public Puzzle2_Door door;

    public bool IsCompleted
    {
        get { return isCompleted; }
    }

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void EntryPuzzles2()
    {
        fragmentParticle.Play();
        // ÁöÁø
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
                audioSource.Play();
                print(isCompleted);
                return;
            }
        }

        isCompleted = true;
        trap2.enabled = false;
        GameManager.instance.PuzzleClear();
        audioSource.Stop();
        if(SoundManager.instance != null)
        {
            SoundManager.instance.PlayBGM(SoundManager.BGM.PlayTheme); 
        }
        print(isCompleted);
        door.DoorOpen();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EntryPuzzles2();
        }
    }
}