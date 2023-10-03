using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3_Door : MonoBehaviour
{
    private bool isOpen = false;
    private float openSpeed = 60f;
    private Vector3 euler;

    private Vector3 targetEuler = new Vector3(0f, 140f, 0f);

    public Transform rightDoor;
    public Transform leftDoor;

    void Start()
    {
        euler = leftDoor.localEulerAngles;
    }

    void Update()
    {
        rightDoor.localEulerAngles = Vector3.Lerp(rightDoor.localEulerAngles, targetEuler, Time.deltaTime);

        euler = Vector3.Lerp(euler, -targetEuler, Time.deltaTime);
        leftDoor.localEulerAngles = euler;
    }

    public void OpenDoor()
    {
        isOpen = true;
    }
}
