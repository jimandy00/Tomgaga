using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UI;

// 스폰 포인트 일정 구간에 플레이어가 감지되면
// 플레이어가 죽음 상태일 때 스폰 포인트에 플레이어를 위치시킨다.
public class Spawn : MonoBehaviour
{
    Player player;
    public GameObject originSpawnPoint;

    bool spawnState;

    PlayerDie playerDie;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        player.savedSpawnPoint = originSpawnPoint.transform.position; // spawnPoint01의 위치로 초기화

        playerDie = GetComponent<PlayerDie>();
    }

    public bool completeRespawn;
    public void ReSpawn()
    {
        print("리스폰 실행되나?");
        transform.position = player.savedSpawnPoint; // 저장된 스폰 포인트로 플레이어 이동
        GameManager.instance.PuzzlesReset(); // 퍼즐 리셋
        player.playerState = true; // 플레이어 상태 '생존'으로 변경
        completeRespawn = true;
        //playerDie.pushZ = false;
        print(playerDie.pushZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint")) // 플레이어가 트리거에 닿이면?
        {
            player.savedSpawnPoint = other.transform.position; // 플레이어 스폰 포인트 갱신
            print("스폰 포인트 갱신 : " + other.gameObject.name);
        }
    }
}