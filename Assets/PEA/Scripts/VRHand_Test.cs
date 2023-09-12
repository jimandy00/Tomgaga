using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHand_Test : MonoBehaviour
{
    private Slot slot;

    public OVRInput.Controller controller;
    public Transform grabPos;

    private GameObject item;
    private bool isGrab = false;

    public GameObject inventory;

    void Start()
    {
        
    }

    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller))
        {
            if(slot!= null && item.transform.IsChildOf(slot.transform))
            {
                slot.TakeItemOut(grabPos);
                //item.transform.SetParent(grabPos);
                //item.transform.localPosition = Vector3.zero;
                isGrab = true;
            }
            else if (item != null)
            {
                item.transform.SetParent(grabPos);
                item.transform.localPosition = Vector3.zero;
                isGrab = true;
            }
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, controller))
        {
            isGrab = false;
            if (slot != null && item != null)
            {
                slot.GetItem(item);
                item = null;
            }
            else
            {
                if(item != null)
                {
                    item.transform.SetParent(null);
                }
            }
        }

        if(controller == OVRInput.Controller.LTouch && OVRInput.GetDown(OVRInput.Button.Two, controller))
        {
            inventory.SetActive(!inventory.activeSelf);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabbable") && !isGrab)
        {
            item = other.gameObject;
        }
        else if (other.CompareTag("Slot"))
        {
            slot = other.GetComponent<Slot>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == item)
        {
            item = null;
        }
        else if (slot != null && other.gameObject ==  slot.gameObject)
        {
            slot = null;
        }
    }
}
