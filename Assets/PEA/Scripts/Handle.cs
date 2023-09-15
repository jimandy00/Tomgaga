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
    private readonly float maxRotX = 0f;
    private readonly float minRotX = -90f;

    private Vector3 originEulerAngle;
    private Vector3 eulerAngle;

    void Start()
    {
        eulerAngle = originEulerAngle = transform.localEulerAngles;
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
        eulerAngle.z = Mathf.Clamp(eulerAngle.z, minRotX, maxRotX);
        //if(handleType == HandleType.Right)
        //{
        //    eulerAngle.z = Mathf.Clamp(eulerAngle.z, rightHandleMinZ, rightHandleMaxZ);
        //    if(eulerAngle.z == rightHandleMinZ)
        //    {
        //        Puzzle1.instance.RotRevolvingDoor(handleType);
        //        enabled = false;
        //    }
        //}
        //else
        //{
        //    eulerAngle.z = Mathf.Clamp(eulerAngle.z, leftHandleMinZ, leftHandleMaxZ);
        //    if (eulerAngle.z == leftHandleMaxZ)
        //    {
        //        Puzzle1.instance.RotRevolvingDoor(handleType);
        //        enabled = false;
        //    }
        //}
        transform.localEulerAngles = eulerAngle;
    }

    public void ResetHandle()
    {
        eulerAngle = originEulerAngle;
        transform.localEulerAngles = eulerAngle;
    }
}
