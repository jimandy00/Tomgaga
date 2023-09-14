using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_Mural : MonoBehaviour
{
    private bool hasStone = true;

    public bool HasStone
    {
        get { return hasStone; }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            hasStone = false;
            Puzzle2.instance.CheckIsComplete();
        }
    }
}
