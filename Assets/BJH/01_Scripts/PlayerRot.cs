using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카메라 회전
public class PlayerRot : MonoBehaviour
{
    public float rotSpeed = 300f;

    // 회전값 변수
    float mx = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouse_X = Input.GetAxis("Mouse X");

        // 회전값 변수에 마우스 입력값만큼 미리 누적
        mx += mouse_X * rotSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, mx, 0);
    }
}
