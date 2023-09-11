using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    public enum HandleState
    {
        None,
        Left,
        Right
    }

    private HandleState handleState = HandleState.None;

    private float maxRotZ = 20f;
    private Vector3 leftHandleEulerAngle;
    private Vector3 rightHandleEulerAngle;
    private Transform leftHandle;
    private Transform rightHandle;

    public RevolvingDoor revolvingDoor;

    void Start()
    {
        leftHandle = transform.GetChild(0);
        rightHandle = transform.GetChild(1);

        leftHandleEulerAngle = leftHandle.localEulerAngles;
        rightHandleEulerAngle = rightHandle.localEulerAngles;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(handleState != HandleState.Left)
            {
                handleState = HandleState.Left;
                revolvingDoor.RotateRevolvingDoor(handleState);
            }
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(handleState != HandleState.Right)
            {
                handleState = HandleState.Right;
                revolvingDoor.RotateRevolvingDoor(handleState);
            }
        }

        switch (handleState)
        {
            case HandleState.None:
                break;

            case HandleState.Left:
                if(leftHandleEulerAngle.z > -maxRotZ)
                {
                    leftHandleEulerAngle.z -= Time.deltaTime * 80f;
                    leftHandle.localEulerAngles = leftHandleEulerAngle;
                }

                if(rightHandleEulerAngle.z > 0)
                {
                    rightHandleEulerAngle.z -= Time.deltaTime * 80f;
                    rightHandle.localEulerAngles = rightHandleEulerAngle;
                }

                break;

            case HandleState.Right:
                if (leftHandleEulerAngle.z < 0)
                {
                    leftHandleEulerAngle.z += Time.deltaTime * 80f;
                    leftHandle.localEulerAngles = leftHandleEulerAngle;
                }

                if (rightHandleEulerAngle.z < maxRotZ)
                {
                    rightHandleEulerAngle.z += Time.deltaTime * 80f;
                    rightHandle.localEulerAngles = rightHandleEulerAngle;
                }
                break;
        }
    }
}
