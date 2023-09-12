using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    public GameObject inven;

    void Start()
    {
        inven.SetActive(false);    
    }

    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            print(inven.activeSelf);
            inven.SetActive(!inven.activeSelf); // 켜져있으면 꺼지고 꺼져있으면 켜짐
            
        }
    }
}
