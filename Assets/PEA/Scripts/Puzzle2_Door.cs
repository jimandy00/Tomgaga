using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_Door : MonoBehaviour
{
    private bool isOpen = false;
    private Vector3 targetPos;

    private void Start()
    {
        targetPos = transform.localPosition;
        targetPos.x = -39.5f;
    }

    void Update()
    {
        if (isOpen && transform.localPosition.x < -39.5f)
        {
            transform.localPosition += transform.forward * 0.5f * Time.deltaTime;
        }
    }

    public void DoorOpen()
    {
        isOpen = true;
    }
}
