using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// dash
public class Dash : MonoBehaviour
{
    // dash 속도
    public float speed = 1.5f;

    // dash 판별
    bool isDash;

    // Controller
    public OVRInput.Controller controller;
    public OVRInput.Button dashBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(dashBtn, controller))
        {
            if(isDash == false)
            {
                isDash = true;
                
            }
        }
    }
}
