using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카메라 회전
// 요소 : 카메라, 회전 속도
public class CameraRot : MonoBehaviour
{
    // 회전 속도
    public float rotSpeed = 200f;

    float mx = 0;
    float my = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 마우스로 입력 받기(좌우)
        float Mouse_X = Input.GetAxis("Mouse X");
        float Mouse_Y = Input.GetAxis("Mouse Y");

        // 회전값 변수에 마우스 입력 값만큼 미리 누적
        mx += Mouse_X * rotSpeed * Time.deltaTime;
        my += Mouse_Y * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90);

        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
