using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    public GameObject inven;
    bool invenState;

    public GameObject lightGo;

    // 손전등
    public GameObject light;
    bool lightState = false;

    // 손전등 on/off audio
    public AudioSource lightAudio;

    public AudioSource invenOpenAudio;
    public AudioSource invenCloseAudio;




    void Start()
    {
        inven.SetActive(false);

        lightGo.SetActive(false);
        light.SetActive(false);
        lightState = false;

        lightAudio.enabled = false;
    }

    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch) || Input.GetKeyDown(KeyCode.I))
        {
            if(invenState == false)
            {
                inven.SetActive(true);
                invenState = true;
                invenOpenAudio.Play();
            }

            else if(invenState == true)
            {
                inven.SetActive(false);
                invenState = false;
                invenCloseAudio.Play();
            }
            //inven.SetActive(!inven.activeSelf); // 켜져있으면 꺼지고 꺼져있으면 켜짐
        }

        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(lightState == false)
            {
                lightGo.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                lightGo.SetActive(true);
                light.SetActive(true);
                lightAudio.enabled = true;
                lightAudio.Play();


                lightState = true;
            }
            else
            {
                lightGo.SetActive(false);
                light.SetActive(false);
                lightAudio.Play();

                lightState = false;
            }
        }
    }


}
