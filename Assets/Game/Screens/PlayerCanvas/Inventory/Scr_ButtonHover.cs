using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ButtonHover : MonoBehaviour
{
    Scr_Inventory Inventory;
    public Scr_InventoryChest Chest;

    public int ButtonUsesPos;

    // Start is called before the first frame update
    void Start()
    {
        Inventory = transform.parent.parent.parent.parent.GetComponent<Scr_Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHover()
    {
        if(!Inventory.isUses)
        {
            Inventory.ItemsSel.transform.parent = gameObject.transform;
            Inventory.ItemsSel.transform.position = gameObject.transform.position;

            Inventory.ItemsPos = gameObject.GetComponentInChildren<Scr_InventoryButtonData>().ButtonPos;

            if(Chest.ItemsSel.activeInHierarchy)
            {
                Chest.ItemsSel.SetActive(false);
                Inventory.ItemsSel.SetActive(true);
            }
        }
    }

    public void OnHoverUses()
    {
        if (Inventory.isUses)
        {
            Inventory.UsesSel.transform.parent = gameObject.transform;
            Inventory.UsesSel.transform.position = gameObject.transform.position;

            Inventory.UsesPos = ButtonUsesPos;
        }

    }
}
