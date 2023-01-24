using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ButtonHover_Chest : MonoBehaviour
{
    Scr_InventoryChest InventoryChest;
    public Scr_Inventory Inventory;

    public int ButtonPos;

    // Start is called before the first frame update
    void Start()
    {
        InventoryChest = transform.parent.parent.parent.GetComponent<Scr_InventoryChest>();
    }


    public void OnHover()
    {
        if (gameObject.activeInHierarchy)
        {
            InventoryChest.ItemsSel.transform.parent = gameObject.transform;
            InventoryChest.ItemsSel.transform.position = gameObject.transform.position;

            InventoryChest.ItemsPos = ButtonPos;

            if (Inventory.ItemsSel.activeInHierarchy)
            {
                InventoryChest.ItemsSel.SetActive(true);
                Inventory.ItemsSel.SetActive(false);
            }
        }
    }
}
