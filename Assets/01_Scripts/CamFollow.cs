using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카메라의 위치를
// CamPosition으로 옮긴다.
public class CamFollow : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;    
    }
}
