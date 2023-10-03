using PEA;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TocuhStartBtn : MonoBehaviour
{
    public OVRInput.Button handTrigger;
    public OVRInput.Controller rTouch;
    
    bool isGrab;

    GameStart gameStart;

    private void Start()
    {
        gameStart = GetComponent<GameStart>();
    }

    void Update()
    {
        if (OVRInput.GetDown(handTrigger, rTouch))
        {
            isGrab = true;
        }

        // test¿ë
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameStart.OnClickStart();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 1.0f);

        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].gameObject.name == "canvasGo" && isGrab == true)
            {
                gameStart.OnClickStart();
                isGrab = false;
            }
        }
    }

}
