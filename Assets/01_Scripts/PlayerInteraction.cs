using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    bool ishold = false;

    GameObject go;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Cube")
        {
            print("큐브를 잡았습니다.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Cube" && ishold == false)
        {
            ishold = true;

            go = other.gameObject;

            go.transform.position = transform.position;

            float f = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
            print(f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("탈출");
    }
}
