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
    private float prevY = 0;

    // 잡기 정보
    bool isGrab = false;

    // 잡고있는 오브젝트 정보
    GameObject grabGo;

    // 손 살짝 위
    public GameObject getGoPosition;

    // 놓아버린 오브젝트들을 담는 empty gameobject
    public GameObject putDown;

    // 인벤에서 아이템 놓는 칸 하나하나
    private Slot slot;

    // Start is called before the first frame update
    void Start()
    {
        hole = GetComponent<Hole>();
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            if (isGrab == false)
                return;

            Collider[] cols = Physics.OverlapSphere(transform.position, 0.5f);

            if (slot != null)
            {
                print("슬롯에서 아이템 꺼내기");
                grabGo = slot.TakeItemOut(transform);
            }

            // 아니면 가장 가까이 있는 아이템 잡음
            else
            {
                print("가까이 있는 아이템 잡기");
                grabGo = CompareDistance(cols);
            }

            grabGo.GetComponent<Rigidbody>().isKinematic = true;
            grabGo.transform.parent = getGoPosition.transform;
            grabGo.transform.localPosition = Vector3.zero;
            isGrab = true;
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            print("111111111");
            Collider[] cols = Physics.OverlapSphere(transform.position, 0.5f);
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].gameObject.CompareTag("Handle"))
                {
                    print("handle");
                    if (prevY == 0)
                    {
                        prevY = transform.position.y;
                    }

                    Handle handle = cols[i].transform.GetComponent<Handle>();
                    print(prevY);

                    

                    handle.HoldHandle(prevY - transform.position.y);
                    prevY = transform.position.y;
                }
            }
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            //print("놓기 버튼을 눌렀습니다.");
            if(slot != null && grabGo != null)
            {
                print(slot.name);
                slot.GetItem(grabGo);
                grabGo = null;
                isGrab = false;
            }
            else if(grabGo != null)
            {
                grabGo.transform.parent = null;
                grabGo.GetComponent<Rigidbody>().isKinematic = false;
                isGrab = false;
            }

            prevY = 0;

        }
    }

    // 거리 비교
    private GameObject CompareDistance(Collider[] cols)
    {
        Collider nearest = null;
        float nearestDistance = float.MaxValue;

        foreach (Collider collider in cols)
        {
            if (!collider.CompareTag("Target"))
                continue;

            float distance = Vector3.Distance(transform.position, collider.transform.position);
            if (distance < nearestDistance)
            {
                nearest = collider;
                nearestDistance = distance;                
            }
        }

        return nearest.gameObject;
    }

    GameObject stone;
    bool isStone;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Slot"))
        {
            slot = other.GetComponent<Slot>();
        }
        // 만약 other이 돌이라면?
        else if(other.CompareTag("Stone"))
        {
            // 함수 실행
            hole.TakeStoneOut();

            // 돌을 잡았다!
            isStone = true;

            // 잡은 돌을 stone에 대입
            stone = other.gameObject;

            // 돌의 위치를 손 살짝 위로 옮긴다.
            other.transform.position = getGoPosition.transform.position;
        }
    }

    Hole hole;
    private void OnTriggerExit(Collider other)
    {
        if(slot != null && other.gameObject == slot.gameObject)
        {
            slot = null;
        }

        // 만약 other 구멍이라면?
        // 그리고 손에 돌이 들려있다면?
        if(other.CompareTag("Hole") && isStone == true)
        {
            hole.PutStone(stone);

            // 돌을 내려놨다.
            isStone = false;
        }
    }
}
