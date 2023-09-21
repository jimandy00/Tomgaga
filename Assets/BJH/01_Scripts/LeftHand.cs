using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    public GameObject inven;
    public GameObject lightGo;

    // 손전등
    public GameObject light;
    bool lightState = false;

    // 손전등 on/off audio
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        inven.SetActive(false);

        lightGo.SetActive(false);
        light.SetActive(false);
        lightState = false;

        audio.enabled = false;
    }

    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            print(inven.activeSelf);
            inven.SetActive(!inven.activeSelf); // 켜져있으면 꺼지고 꺼져있으면 켜짐
        }

        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(lightState == false)
            {
                lightGo.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                lightGo.SetActive(true);
                light.SetActive(true);
                audio.enabled = true;
                audio.Play();


                lightState = true;
            }
            else
            {
                lightGo.SetActive(false);
                light.SetActive(false);
                audio.Play();

                lightState = false;
            }
        }
    }


}
