using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 이동
// 플레이어 오브젝트, 입력 키, 이동 속도, 방향
public class PlayerMove : MonoBehaviour
{
    // 속도
    public float speed = 3f;

    // 카메라
    public GameObject rig;

    // 움직이는 상태
    bool isMoving;

    // 오디오
    AudioSource audio;

    // 

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // 이동값 가져오기
        Vector2 axix = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);

        // Vector2는 reference가 아니라서 value값임. 그래서 vector2.zero로 해야됨!!
        if(axix != Vector2.zero && isMoving == false) // 안움직이다가 움직이게 됐을 때
        {
            audio.Play();
            audio.loop = true;
            isMoving = true;
        }
        else if(axix == Vector2.zero)
        {
            audio.loop = false;
            isMoving = false;
        }


        // 방향 설정하기
        Vector3 dir = new Vector3(axix.x, 0, axix.y);

        // 상대좌표
        dir = rig.transform.TransformDirection(dir);

        dir = dir.normalized;



        // 이동하기
        transform.position += dir * speed * Time.deltaTime;



        // 테스트 편하게 하고싶어서 키보드 값도 넣었습니다.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 k_dir = new Vector3(h, 0, v);

        k_dir = rig.transform.TransformDirection(k_dir);

        transform.position += k_dir * speed * Time.deltaTime;



    }

}

