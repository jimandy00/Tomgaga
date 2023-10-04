using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾��� ���� ���
// ��ư�� ������ �ݰ��� ����
// �ش��ϴ� �ݰ濡 ���� �� �ִ� ������Ʈ�� �ִٸ� []�� ���
// �ش� ������Ʈ�� �� ��ġ�� �̵�(�����尡 �ִٸ� Ű�׸�ƽ�� true)

// �÷��̾��� ���� ����
// �� ���� ��������
public class Grab : MonoBehaviour
{
    private float prevY = 0;

    // ��� ����
    bool isGrab = false;

    // ����ִ� ������Ʈ ����
    GameObject grabGo;

    // �� ��¦ ��
    public GameObject getGoPosition;

    // ���ƹ��� ������Ʈ���� ��� empty gameobject
    public GameObject putDown;

    // �κ����� ������ ���� ĭ �ϳ��ϳ�
    private Slot slot;

    private Puzzle2_Mural mural;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {

            Collider[] cols = Physics.OverlapSphere(transform.position, 0.5f, 1 << LayerMask.NameToLayer("Target"));

            if (cols.Length == 0)
                return;

            if (slot != null)
            {
                print("���Կ��� ������ ������");
                grabGo = slot.TakeItemOut(transform);
            }
            else if (hole != null)
            {
                print("h");
                // ���ۿ��� �� ������
                grabGo = hole.TakeStoneOut();
            }

            // �ƴϸ� ���� ������ �ִ� ������ ����
            else 
            {
                print("������ �ִ� ������ ���");
                grabGo = CompareDistance(cols);
                if(grabGo.CompareTag("Stone"))
                {
                    isStone = true;
                    if(mural != null)
                    {
                        mural.IsStoneStay();
                    }
                }
            }

            //grabGo.GetComponent<Rigidbody>().isKinematic = true;
            if(grabGo != null)
            {
                grabGo.transform.parent = getGoPosition.transform;
                grabGo.transform.localPosition = Vector3.zero;
                isGrab = true;
            }
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
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
                    //print(prevY);

                    

                    handle.HoldHandle(prevY - transform.position.y);
                    prevY = transform.position.y;
                }
            }
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            //print("���� ��ư�� �������ϴ�.");
            if(slot != null && grabGo != null)
            {
                print(slot.name);
                slot.GetItem(grabGo);
            }
            else if (hole != null && isStone == true)
            {
                print("�� �ֱ�");
                hole.PutStone(grabGo);

            }
            else if(grabGo != null)
            {
                grabGo.transform.parent = null;
                //grabGo.GetComponent<Rigidbody>().isKinematic = false;
            }

            prevY = 0;

            grabGo = null;
            isGrab = false;
            isStone = false;
        }
    }

    // �Ÿ� ��
    private GameObject CompareDistance(Collider[] cols)
    {
        Collider nearest = null;
        float nearestDistance = float.MaxValue;

        if(cols.Length > 0)
        {
            foreach (Collider collider in cols)
            {         
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < nearestDistance)
                {
                    nearest = collider;
                    nearestDistance = distance;                
                }
            }
            return nearest.gameObject;
        }
        else
        {
            return null;
        }


    }

    GameObject stone;
    bool isStone;
    Hole hole;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Slot"))
        {
            slot = other.GetComponent<Slot>();
        }
        
        // ���� other�� Ȧ�̶��?
        else if(other.CompareTag("Hole"))
        {
            print("h enter");
            hole = other.GetComponent<Hole>();
        }

        else if (other.CompareTag("Mural"))
        {
            mural = other.GetComponent<Puzzle2_Mural>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(slot != null && other.gameObject == slot.gameObject)
        {
            slot = null;
        }

        // ���� other �����̶��?
        // �׸��� �տ� ���� ����ִٸ�?
        if (hole != null && other.gameObject == hole.gameObject)
        {
            print(" h exit");
            hole = null;
        }

        if(mural != null && other.gameObject == mural.gameObject)
        {
            mural = null;
        }
    }
}
