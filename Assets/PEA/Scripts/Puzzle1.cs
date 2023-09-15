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

    public RevolvingDoor revolvingDoor;
    public Handle[] handles;

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
    }

    public void RotRevolvingDoor(Handle.HandleType handleType)
    {
        if(handleType == Handle.HandleType.Right)
        {
            handleState = HandleState.Right;
        }
        else
        {
            handleState = HandleState.Left;
        }

        revolvingDoor.RotateRevolvingDoor(handleState);
    }

    public void ResetPuzzle()
    {
        handleState = HandleState.None;
        foreach (Handle handle in handles)
        {
            handle.ResetHandle();
        }
        revolvingDoor.ResetRevolvingDoor();
    }
}
