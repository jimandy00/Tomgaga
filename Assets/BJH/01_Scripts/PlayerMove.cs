using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 이동
// 플레이어 오브젝트, 입력 키, 이동 속도, 방향
public class PlayerMove : MonoBehaviour
{
    // 속도
    public float speed;
    public float walkSpeed = 0.5f;

    // 카메라
    public GameObject rig;

    // 움직이는 상태
    bool isMoving;

    // audio
    public AudioSource walkAudio;
    public AudioSource dashAudio;

    public Spawn spawn;

    bool isDash;

    // Controller
    public OVRInput.Controller lController;
    public OVRInput.Controller RController;
    public OVRInput.Button dashBtn;
    public OVRInput.Axis2D moveStick;

    // Start is called before the first frame update
    void Start()
    {
        speed = walkSpeed;
        rd = GetComponent<Rigidbody>();
        isDash = false;

        dashAudio.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어 임의로 죽이기
        if(Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("플레이어를 죽였습니다.");
            spawn.playerState = false;
        }

        // 이동값 가져오기
        Vector2 axix = OVRInput.Get(moveStick, lController);

        // Vector2는 reference가 아니라서 value값임. 그래서 vector2.zero로 해야됨!!
        if(axix != Vector2.zero && isMoving == false) // 안움직이다가 움직이게 됐을 때
        {
            walkAudio.Play();
            walkAudio.loop = true;
            isMoving = true;
        }
        else if(axix == Vector2.zero)
        {
            walkAudio.loop = false;
            isMoving = false;
        }

        if (OVRInput.Get(dashBtn, RController) && !isDash)
        {
            Debug.Log("dash 버튼을 눌렀습니다.");
            Dash();
        }

        else if(OVRInput.GetUp(dashBtn, RController) && isDash)
        {
            EndDash();
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




    // dash
    Rigidbody rd;
    public float dashSpeed = 10f;

    private void Dash()
    {
        //rd.AddForce(transform.forward * dashSpeed, ForceMode.Impulse);
        isDash = true;
        speed = dashSpeed;
        dashAudio.enabled = true;
        dashAudio.loop = true;
        //StartCoroutine(CoDash());
    }

    private void EndDash()
    {
        isDash = false;
        speed = walkSpeed;
        dashAudio.enabled = false;
        dashAudio.loop = false;

    }



    public float dashTime;
    //IEnumerator CoDash()
    //{
    //    dashAudio.enabled = true;
    //    dashAudio.loop = true;
    //    yield return new WaitForSeconds(dashTime);
    //    isDash = false;
    //    dashAudio.enabled = false;
    //    dashAudio.loop = false;
    //}
}

