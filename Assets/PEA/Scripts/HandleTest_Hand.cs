using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTest_Hand : MonoBehaviour
{
    float prevY;
     public Handle handle;

    void Start()
    {
        prevY = transform.position.y;
    }

    void Update()
    {
        handle.HoldHandle(prevY - transform.position.y);
        prevY = transform.position.y;
    }
}
