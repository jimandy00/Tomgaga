using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    private bool hasItem = false;
    private bool isClicked = false;
    private Coroutine coroutine = null;

    private int itemCount;
    private ItemInformation itemInfo;
    public TMP_Text itemCountText;

    public Inventory inventory;

    private void Start()
    {
        itemInfo = GetComponent<ItemInformation>();
    }

    public void GetItem(GameObject item)
    {
        if (hasItem)
        {
            if (item.GetComponent<ItemInformation>().GetItemInfo().ItemName.Equals(itemInfo.GetItemInfo().ItemName))
            {
                itemCountText.gameObject.SetActive(true);
                itemCount++;
                itemCountText.text = itemCount.ToString();
                print("1111");
            }
            else
            {
                item.transform.SetParent(null);
                print("222");
                return;
            }
        }
        else
        {
            hasItem = true;
            itemInfo.item = item.GetComponent<ItemInformation>().GetItemInfo();
            itemCount = 1;
            print("333");
        }

        item.transform.SetParent(transform);
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;
        print(item.name);
    }

    public void TakeItemOut(Transform handTr)
    {
        if (itemCount <= 0)
            return;

        GameObject item = transform.GetChild(1).gameObject;
        item.transform.SetParent(handTr);
        item.transform.position = Vector3.zero;
        itemCount--;
        itemCountText.text = itemCount.ToString();

        if(itemCount < 2)
        {
            itemCountText.gameObject.SetActive(false);
            if(itemCount < 1)
            {
                hasItem = false;
                print("non");
            }
        }
    }

    public void OnClickSlot()
    {
        if (isClicked)
        { 
            inventory.TakeItemOut(transform.GetChild(0).gameObject);
        }
        else
        {
            isClicked = true;
            if (coroutine == null)
            {
                coroutine = StartCoroutine(IOnClickSlot());
            }
            else
            {
                StopCoroutine(coroutine);
                coroutine = StartCoroutine(IOnClickSlot());
            }
        }
    }

    IEnumerator IOnClickSlot()
    {
        yield return new WaitForSeconds(0.3f);

        isClicked = false;
        coroutine = null;
        yield return null;
    }
}