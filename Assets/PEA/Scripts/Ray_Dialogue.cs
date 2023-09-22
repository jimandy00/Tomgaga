using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_Dialogue : MonoBehaviour
{
    private float rayDist = 3f;
    private RaycastHit hit;

    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, rayDist))
        {
            if (hit.transform.CompareTag("Dialogue_Ray"))
            {
                hit.transform.GetComponent<Dialogue>().ShowDialogue();
            }
        }
    }
}
