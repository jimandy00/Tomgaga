using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어가 죽으면
// 스폰 포인트에 플레이어를 생성한다.
// 만약 특정 위치의 트리거를 밟으면
// 스폰 포인트를 해당 위치로 변경한다.
// 요소 : 플레이어 생존 여부, 스폰 포인트 오브젝트정보(트리거를 포함한), 스폰 위치를 저장해 둘 변수
public class Spawn : MonoBehaviour
{
    bool playerState = true;

    public GameObject spawnPoint01;
    public GameObject spawnPoint02;
    public GameObject spawnPoint03;

    Transform savedSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        savedSpawnPoint = spawnPoint01.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerState == false)
        {
            print("플레이어 위치를 " + savedSpawnPoint.position + "로 이동했습니다.");
            transform.position = savedSpawnPoint.position;
            playerState = true;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("플레이어가 죽었습니다.");
            playerState = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("스폰 포인트가 " + other.gameObject.name + "로 변경되었습니다.");
        savedSpawnPoint.position = other.gameObject.transform.position;
    }
}
