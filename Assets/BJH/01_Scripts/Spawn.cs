using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UI;

// 스폰 포인트 일정 구간에 플레이어가 감지되면
// 플레이어가 죽음 상태일 때 스폰 포인트에 플레이어를 위치시킨다.
public class Spawn : MonoBehaviour
{
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
            transform.position = savedSpawnPoint.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        print("스폰 포인트에 닿은 물체 : " + other.gameObject.name);
        string name = other.gameObject.name;
        
        if (name.Contains("Spawn"))
        {
            print("플레이어가 트리거에 닿았습니다.");
            savedSpawnPoint = other.gameObject.transform;
        }
    }
}