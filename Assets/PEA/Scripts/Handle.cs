using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    public enum HandleType
    {
        Right,
        Left
    }

    public HandleType handleType;
    private float rotateIntensity = 45f;

    private float rightHandleMaxZ = 30f;
    private float rightHandleMinZ = 0f;
    private float leftHandleMaxZ = 0f;
    private float leftHandleMinZ = -30f;

    private Vector3 eulerAngle;

    public RevolvingDoor revolvingDoor;

    void Start()
    {
        eulerAngle = transform.localEulerAngles;
        if(eulerAngle.z > 180f)
        {
            eulerAngle.z -= 360f;
        }
    }

    void Update()
    {

    }

    public void HoldHandle(float changeAmoutOfHandY)
    {
        if(!enabled )
            return;
        eulerAngle.z += changeAmoutOfHandY * rotateIntensity;
        if(handleType == HandleType.Right)
        {
            eulerAngle.z = Mathf.Clamp(eulerAngle.z, rightHandleMinZ, rightHandleMaxZ);
            if(eulerAngle.z == rightHandleMinZ)
            {
                Puzzle1.instance.RotRevolvingDoor(handleType);
                enabled = false;
            }
        }
        else
        {
            eulerAngle.z = Mathf.Clamp(eulerAngle.z, leftHandleMinZ, leftHandleMaxZ);
            if (eulerAngle.z == leftHandleMaxZ)
            {
                Puzzle1.instance.RotRevolvingDoor(handleType);
                enabled = false;
            }
        }
        transform.localEulerAngles = eulerAngle;
    }
}
