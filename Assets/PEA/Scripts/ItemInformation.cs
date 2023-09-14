using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private string itemName;

    public string ItemName
    {
        get { return itemName; }
    }

    public Item(string itemName)
    {
        this.itemName = itemName;
    }
}

public class ItemInformation : MonoBehaviour
{
    public string itemName = "";
    public Item item;

    void Start()
    {
        item = new Item(itemName);
    }

    public Item GetItemInfo()
    {
        return item;
    }
}
