using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_Mural : MonoBehaviour
{
    private int stoneCount = 0;
    private bool hasStone = true;
    private List<Vector3> stonesOriginPos = new List<Vector3>();
    private List<Quaternion> stonesOriginRot = new List<Quaternion>();
    private List<GameObject> stones = new List<GameObject>();

    public bool HasStone
    {
        get { return hasStone; }
    }

    void Start()
    {
        foreach (Transform tr in transform)
        {
            stones.Add(tr.gameObject);
            stonesOriginPos.Add(tr.position);
            stonesOriginRot.Add(tr.rotation);
            stoneCount++;
        }
    }

    void Update()
    {
        
    }

    public void ResetMural()
    {
        if (!hasStone)
        {
            for (int i = 0; i < stones.Count; i++)
            {
                if(stones[i].transform.parent.TryGetComponent<Slot>(out Slot slot))
                {
                    slot.TakeItemOut(null);
                }
                stones[i].transform.SetParent(transform);
                stones[i].transform.position = stonesOriginPos[i];
                stones[i].transform.rotation = stonesOriginRot[i];
            }
            
            hasStone = true;
        }
    }

    public void IsStoneStay()
    {
        foreach (GameObject stone  in stones)
        {
            if (!stone.transform.IsChildOf(transform))
            {
                //stones.Remove(stone);
                stoneCount--;
            }
        }
        Puzzle2.instance.CheckIsComplete();
    }

    private void OnTriggerExit(Collider other)
    {
        print("5555555555");
        if (other.CompareTag("Stone"))
        {
            print("stone out");
            stoneCount--;
            //stones.Remove(other.gameObject);

            if(stones.Count == 0)
            {
                hasStone = false;
            }

            Puzzle2.instance.CheckIsComplete();
        }
    }
}
