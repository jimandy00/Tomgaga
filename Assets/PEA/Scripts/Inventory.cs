using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject > items = new List<GameObject>();

    public Transform inventoryContents;
    private GameObject[] itemSlots;

    void Start()
    {
        itemSlots = new GameObject[inventoryContents.childCount];
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i] = inventoryContents.GetChild(i).gameObject;
            print(itemSlots[i].name);
        }

        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    // 인벤토리에 물건 담기
    public void PutItemIntoInventory(GameObject item)
    {
        items.Add(item);
        SetInventory();
    }

    // 인벤토리에 담긴 물건들 UI에 넣어주기
    public void SetInventory()
    {
        int i = 0;
        foreach (GameObject item in items)
        {
            item.transform.SetParent(itemSlots[i].transform);
            item.transform.localPosition = Vector3.zero;
            item.transform.localScale = Vector3.one * 30f;
            i++;
        }
    }

    // 인벤토리에 있는 아이템 꺼내기
    public void TakeItemOut(GameObject item)
    {
        print("꺼내기");
        items.Remove(item);
        item.transform.SetParent(null);
        item.transform.position = Vector3.zero;
        item.transform.localScale = Vector3.one;
        SetInventory();
    }
}
