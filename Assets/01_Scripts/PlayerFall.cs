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

    // camera
    public GameObject camera;
    Vector3 camPos;

    // camera shacke rage
    [SerializeField]
    [Range(0.0f, 0.1f)]
    float shakeRange = 0.05f; // 카메라 흔들림 범위

    [SerializeField]
    [Range(0.1f, 1f)] float duration = 0.5f; // 지속시간

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

            CameraShake();
        }
        stopSake();
        isPlayerFall = false;
    }

    void CameraShake()
    {
        camPos = camera.transform.position;
        InvokeRepeating(nameof(StartShake), 0f, 0.005f);
        Invoke(nameof(StartShake), duration);
    }

    void StartShake()
    {
        float cameraPosX = Random.value * shakeRange * 2 - shakeRange;
        float cameraPosY = Random.value * shakeRange * 2 - shakeRange;

        Vector3 camPos = camera.transform.position;

        camPos.x += cameraPosX;
        camPos.y += cameraPosY;

        camera.transform.position = camPos;
    }

    void stopSake()
    {
        CancelInvoke(nameof(StartShake));
        camera.transform.position = camPos;
    }
}
