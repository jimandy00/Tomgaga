using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 지진이 발생하면
// 카메라가 흔들리는 효과를 주고싶다.
public class CamShake : MonoBehaviour
{
    // 흔들기 지속 시간
    public float shakeTime = 0.5f;

    // 흔들기 세기
    public float shakePower = 0.3f;

    // 카메라 기본 위치
    Vector3 originPosition;

    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            print("카메라가 흔들립니다.");
            StartCoroutine(ShakeCamera(shakePower, shakeTime));
        }
    }

    float timer = 0;
    IEnumerator ShakeCamera(float shakePower, float shakeTime)
    {
        while (timer <= shakeTime)
        {
            print("카메라 흔들리는 중 : " + timer);
            transform.position = Random.insideUnitSphere * shakePower + originPosition;
            timer += Time.deltaTime;
            yield return null;
        }
        transform.position = originPosition;
        timer = 0;
    }
}
