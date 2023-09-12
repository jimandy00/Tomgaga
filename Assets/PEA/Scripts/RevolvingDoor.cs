using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolvingDoor : MonoBehaviour
{
    private Puzzle1.HandleState hState = Puzzle1.HandleState.None;

    private Vector3 eulerAngle;
    private Vector3 failRot;
    private Vector3 rightRot;

    void Start()
    {
        eulerAngle = rightRot = failRot = transform.eulerAngles;
        failRot.y += 90f;
        rightRot.y -= 90f;
    }

    void Update()
    {
        switch (hState)
        {
            case Puzzle1.HandleState.None:
                break;

            case Puzzle1.HandleState.Left:
                if(eulerAngle.y < failRot.y)
                {
                    eulerAngle.y += Time.deltaTime * 180f;
                }
                break;

            case Puzzle1.HandleState.Right:
                print("right");
                if (eulerAngle.y > rightRot.y)
                {
                    eulerAngle.y -= Time.deltaTime * 180f;
                }
                break;
        }
        transform.eulerAngles = eulerAngle;
    }

    public void RotateRevolvingDoor(Puzzle1.HandleState handleState)
    {
        hState = handleState;
    }
}
