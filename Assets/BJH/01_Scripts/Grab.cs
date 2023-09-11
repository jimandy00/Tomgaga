using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 물건 잡기
// 버튼을 누르면 반경을 만듦
// 해당하는 반경에 잡을 수 있는 오브젝트가 있다면 []에 담고
// 해당 오브젝트를 손 위치로 이동(리지드가 있다면 키네메틱을 true)

// 플레이어의 물건 놓기
// 위 과정 역순으로
public class Grab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("잡기 버튼을 눌렀습니다.");

            Collider[] cols = Physics.OverlapSphere(transform.position, 0.5f); // 반경 10cm내

            for(int i=0; i < cols.Length; i++)
            {
                print("가져온 콜라이더" + cols[i] + "가져온 콜라이더의 게임오브젝트 태그 : " + cols[i].gameObject.tag);

                // 만약 잡은 collider의 tag가 targets라면 
                if(cols[i].gameObject.CompareTag("Target"))
                {
                    print("Target Tag를 가진 게임오브젝트를 가져왔습니다.");
                    cols[i].GetComponent<Rigidbody>().isKinematic = true;
                    cols[i].transform.parent = transform;
                }
            }
        }
    }

}
