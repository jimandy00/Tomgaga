using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public static Mouse instance = null;

    private RaycastHit hit;

    private GameObject curSphere;
    public GameObject spherePrefab;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //CreateSphere();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit ))
            {
                if (hit.transform.CompareTag("Sphere"))
                {
                    curSphere = hit.transform.gameObject;
                }
            }
        }
        else if(curSphere != null && Input.GetMouseButtonUp(0))
        {
            DroptStone();
            curSphere = null;
        }

        if (curSphere != null)
        {
            curSphere.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        }
    }

    private void DroptStone()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.transform.TryGetComponent<Hole>(out Hole hole))
            {
                hole.PutStone(curSphere);
            }
        }
    }

    public void CreateSphere()
    {
        curSphere = Instantiate(spherePrefab);
    }
}
