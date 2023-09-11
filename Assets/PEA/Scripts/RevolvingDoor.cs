using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolvingDoor : MonoBehaviour
{
    private Handle.HandleState hState = Handle.HandleState.None;

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
            case Handle.HandleState.None:
                break;

            case Handle.HandleState.Left:
                if(eulerAngle.y < failRot.y)
                {
                    eulerAngle.y += Time.deltaTime * 180f;
                }
                break;

            case Handle.HandleState.Right:
                print("right");
                if (eulerAngle.y > rightRot.y)
                {
                    eulerAngle.y -= Time.deltaTime * 180f;
                }
                break;
        }
        transform.eulerAngles = eulerAngle;
    }

    public void RotateRevolvingDoor(Handle.HandleState handleState)
    {
        hState = handleState;
    }
}
