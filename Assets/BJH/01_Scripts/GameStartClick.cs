using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartClick : MonoBehaviour
{
    public OVRInput.Button handTrigger;
    public OVRInput.Controller rTouch;
    bool isGrab;

    public GameObject canvas;
    GameStart gameStart;

    private void Start()
    {
        gameStart = canvas.GetComponent<GameStart>();
    }
    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(handTrigger, rTouch))
        {
            isGrab = true;
        }

        // 키보드 테스트용
        if(Input.GetKeyDown(KeyCode.Space))
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
