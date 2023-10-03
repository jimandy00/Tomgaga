using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    public static Puzzle1 instance = null;
    public enum HandleState
    {
        None,
        Left,
        Right
    }

    private HandleState handleState = HandleState.None;
    private bool isCompleted = false;

    public bool IsCoimpleted
    {
        get { return isCompleted; }
    }

    public RevolvingDoor revolvingDoor;
    public Handle[] handles;
    public Dialogue entryDialogue;
    public Dialogue hintDialogue;
    public Dialogue doorOpenDialogue;
    public Dialogue failDialogue;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotRevolvingDoor(Handle.HandleType.Left);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotRevolvingDoor(Handle.HandleType.Right);
        }

        if( !isCompleted && !entryDialogue.CanShow && hintDialogue.CanShow)
        {
            hintDialogue.ShowDialogue();
        }
    }

    public void RotRevolvingDoor(Handle.HandleType handleType)
    {
        doorOpenDialogue.ShowDialogue();
        if(handleType == Handle.HandleType.Right)
        {
            handleState = HandleState.Right;
            isCompleted = true;
            if (SoundManagaer.instance != null)
            {
                SoundManagaer.instance.PlayBGM(SoundManagaer.BGM.PlayTheme);
            }
        }
        else
        {
            handleState = HandleState.Left;
        }

        revolvingDoor.RotateRevolvingDoor(handleState);
        foreach (Handle handle in handles)
        {
            handle.enabled = false;
        }
    }

    public void ResetPuzzle()
    {
        handleState = HandleState.None;
        foreach (Handle handle in handles)
        {
            handle.ResetHandle();
        }
        revolvingDoor.ResetRevolvingDoor();

        failDialogue.ShowDialogue();
    }
}
