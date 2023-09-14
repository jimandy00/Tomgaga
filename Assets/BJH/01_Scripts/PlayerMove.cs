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

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        // 이동값 가져오기
        Vector2 axix = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);

        // 방향 설정하기
        Vector3 dir = new Vector3(axix.x, 0, axix.y);
        dir = dir.normalized;

        // 상대좌표
        dir = rig.transform.TransformDirection(dir);

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

