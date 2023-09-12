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

    private void Awake()
    {
        instance = this;
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
}
