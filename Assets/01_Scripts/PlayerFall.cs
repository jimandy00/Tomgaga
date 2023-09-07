using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어가 떨어지면
// 착지하는 곳에 먼지 효과를 넣는다.
// 요소 : 플레이어 떨어졌는지 여부, 플레이어 위치, 파티클 효과
public class PlayerFall : MonoBehaviour
{
    public GameObject dust;
    public ParticleSystem ps;
    bool psStatus = false;

    bool isPlayerFall = false;

    // Start is called before the first frame update
    void Start()
    {
        if(psStatus == false)
        {
            ps.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collisionGo = collision.gameObject.name;
        if(collisionGo == "FallingGround")
        {
            isPlayerFall = true;

            // 플레이어 위치에
            dust.transform.position = transform.position;

            // 파티클 효과를 실행
            ps.Play();
        }

        isPlayerFall = false;
    }
}
