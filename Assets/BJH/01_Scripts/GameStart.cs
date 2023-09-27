using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public OVRInput.Button handTrigger;
    public OVRInput.Controller rTouch;
    bool isGrab;

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(handTrigger, rTouch))
        {
            isGrab = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 1.0f);

        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].gameObject.name == "canvasGo" && isGrab == true)
            {
                SceneManager.LoadScene(2);
                isGrab = false;
            }
        }
    }

}
