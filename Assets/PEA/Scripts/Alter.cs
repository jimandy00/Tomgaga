using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alter : MonoBehaviour
{
    public LastMural lastMural;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MuralPiece"))
        {
            other.transform.SetParent(transform);
            lastMural.ChangePos();
        }
    }
}
