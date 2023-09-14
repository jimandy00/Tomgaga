using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 핸들을 일정 각도 이상 내리면
// 문이 열리는 함수를 사용

// 핸들을 일정 각도 이하로 내리면
// 핸들 원상복구
public class OpenDoor : MonoBehaviour
{
    // 핸들
    public GameObject handle;


    public void Update()
    {
        // 핸들을 잡고 아래로 누르기
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            // 클릭 하자마자 수직으로 변경됨
            //
            //handle.transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));

            // 서서히 내려가는 방법?
            // rotation -50 ~ -100
            float z = transform.rotation.z;

        }
    }
}
