using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2Test : MonoBehaviour
{
    public Trap2 t2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            t2.enabled = true;
        }
    }
}
