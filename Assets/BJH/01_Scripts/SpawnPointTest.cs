using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스폰 포인트에서 일정 크기의 구를 만들고 
//그 안에 플레이어가 들어오면 
//해당하는 위치를 스폰 포인트로 지정하기
//(단, 해당하는 위치는 바닥 아래에 숨겨져 있으므로 Y값을 임의로 조정)
public class SpawnPointTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 10f, transform.forward, 0.001f);
    }
}
