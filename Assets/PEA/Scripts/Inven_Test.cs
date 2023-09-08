using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven_Test : MonoBehaviour
{
    private RaycastHit hit;

    private bool isOpen = false;
    public Inventory inventory;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isOpen)
            {
                isOpen = false;
                inventory.gameObject.SetActive(false);
            }
            else
            {
                isOpen = true;
                inventory.gameObject.SetActive(true);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if(hit.transform.TryGetComponent<ItemInformation>(out ItemInformation itemInfo))
                {
                    print(hit.transform.name);
                    inventory.PutItemIntoInventory(hit.transform.gameObject);
                }
            }
        }
    }
}
