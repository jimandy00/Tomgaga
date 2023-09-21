using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UI;

// 스폰 포인트 일정 구간에 플레이어가 감지되면
// 플레이어가 죽음 상태일 때 스폰 포인트에 플레이어를 위치시킨다.
public class Spawn : MonoBehaviour
{
    public GameObject player;
    bool playerState;
    Transform savedSpawnPoint;

    
    // Start is called before the first frame update
    void Start()
    {
        playerState = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerState == false || Input.GetKeyDown(KeyCode.Q))
        {
            player.transform.position = savedSpawnPoint.position;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        print("스폰 포인트에 닿은 물체 : " + collision.gameObject.name);
        if(collision.gameObject.name.CompareTo("Player") == 0)
        {
            savedSpawnPoint.position = transform.position;
        }
    }
}