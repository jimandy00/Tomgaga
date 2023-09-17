using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UI;

// 스폰 포인트 일정 구간에 플레이어가 감지되면
// 플레이어가 죽음 상태일 때 스폰 포인트에 플레이어를 위치시킨다.
public class Spawn : MonoBehaviour
{
    bool playerState = true;
    Transform savedSpawn;

    public GameObject spawnPoint;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 20f);

        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].name == "Player")
            {
                savedSpawn = spawnPoint.transform;
                
            }
        }

        if(playerState == false || Input.GetKeyDown(KeyCode.Q)) // 플레이어가 죽음
        {
            Player.transform.position = savedSpawn.position;
        }
    }
}