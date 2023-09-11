using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private bool isClicked = false;
    private Coroutine coroutine = null;

    public Inventory inventory;

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