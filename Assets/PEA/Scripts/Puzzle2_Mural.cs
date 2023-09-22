using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_Mural : MonoBehaviour
{
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

    private void OnTriggerExit(Collider other)
    {
        if (stones.Contains(other.gameObject))
        {
            stones.Remove(other.gameObject);

            if(stones.Count == 0)
            {
                hasStone = false;
            }

            Puzzle2.instance.CheckIsComplete();
        }
    }
}
