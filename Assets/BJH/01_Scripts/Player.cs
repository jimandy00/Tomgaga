using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool playerState;
    public Vector3 savedSpawnPoint;
    public PlayerDie playerDie;
    void Start()
    {
        playerDie = GetComponent<PlayerDie>();
        playerState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerState == false) // 만약 플레이어 상태가 죽음이 된다면?
        {
            playerDie.Die(); // 플레이어 죽음 Ui 및 재시작 기능을 실행
        }   
    }
}
