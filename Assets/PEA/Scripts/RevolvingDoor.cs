using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolvingDoor : MonoBehaviour
{
    private Puzzle1.HandleState hState = Puzzle1.HandleState.None;

    private Vector3 originEulerAngle;
    private Vector3 eulerAngle;
    private Vector3 failRot;
    private Vector3 rightRot;
    private readonly float failRotY = 0;
    private readonly float rightRotY = -90;

    void Start()
    {
        eulerAngle = originEulerAngle = failRot = rightRot = transform.eulerAngles;
        failRot.y = failRotY;
        rightRot.y = rightRotY;
    }

    void Update()
    {
        switch (hState)
        {
            case Puzzle1.HandleState.None:
                break;

            case Puzzle1.HandleState.Left:
                eulerAngle = Vector3.Lerp(eulerAngle, failRot, Time.deltaTime * 2f);
                break;

            case Puzzle1.HandleState.Right:
                eulerAngle = Vector3.Lerp(eulerAngle, rightRot, Time.deltaTime * 2f);
                break;
        }

        if(eulerAngle.y > 180)
        {
            eulerAngle.y -= 360f;
        }

        transform.eulerAngles = eulerAngle;
    }

    public void RotateRevolvingDoor(Puzzle1.HandleState handleState)
    {
        hState = handleState;
    }

    public void ResetRevolvingDoor()
    {
        eulerAngle = originEulerAngle;
        transform.eulerAngles = eulerAngle;
    }
}
