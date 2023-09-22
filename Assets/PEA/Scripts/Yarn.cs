using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yarn : MonoBehaviour
{
    private Dialogue dialogue;

    public Transform handGrabPos;

    void Start()
    {
        dialogue = GetComponent<Dialogue>();
    }

    void Update()
    {
        if (transform.IsChildOf(handGrabPos))
        {
            dialogue.ShowDialogue();
            enabled = false;
        }
    }
}
