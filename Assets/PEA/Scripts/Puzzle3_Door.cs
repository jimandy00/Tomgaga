using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3_Door : MonoBehaviour
{
    private bool isOpen = false;
    private Vector3 euler;

    void Start()
    {
        euler = transform.localEulerAngles;

        isOpen = true;
    }

    void Update()
    {
        if(isOpen && euler.y > -135f)
        {
            euler.y -= 30f * Time.deltaTime;
            transform.localEulerAngles = euler;
        }
    }
}
