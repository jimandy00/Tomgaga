using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3_Stone : MonoBehaviour
{
    private Dialogue dialogue;

    public Transform handGrapPos;

    void Start()
    {
        dialogue = GetComponent<Dialogue>();
    }

    void Update()
    {
        if (transform.IsChildOf(handGrapPos))
        {
            dialogue.ShowDialogue();
        }
    }
}
