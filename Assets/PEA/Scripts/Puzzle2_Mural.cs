using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_Mural : MonoBehaviour
{
    private bool hasStone = true;
    private Vector3 stoneOriginPos;
    private Quaternion stoneOriginRot;
    private GameObject stone;

    public bool HasStone
    {
        get { return hasStone; }
    }

    void Start()
    {
        stone = transform.GetChild(0).gameObject;
        stoneOriginPos = stone.transform.position;
        stoneOriginRot = transform.rotation;
    }

    void Update()
    {
        
    }

    public void ResetMural()
    {
        if (!hasStone)
        {
            if(stone.transform.parent.TryGetComponent<Slot>(out Slot slot))
            {
                slot.TakeItemOut(null);
            }
            stone.transform.SetParent(transform);
            stone.transform.position = stoneOriginPos;
            stone.transform.rotation = stoneOriginRot;
            
            hasStone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == stone)
        {
            hasStone = false;
            Puzzle2.instance.CheckIsComplete();
        }
    }
}
