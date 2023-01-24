using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_InventoryChest : MonoBehaviour
{
    public Scr_InputSystem Inputs;
    public Scr_Inventory Inventory;
    

    public Scr_Baul Baul;

    [Header("Menu de Items")]
    public int ItemsPos = 0;
    [Space]
    public GameObject ItemsMenu;
    public GameObject ItemsSel;
    [Space]
    public GameObject[] Items;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Inventory.isUses)
        {
            if (Inputs.OpenInventory || Inputs.Cancel)
            {
                if (ItemsMenu.activeSelf)
                {
                    gameObject.SetActive(false);

                    Baul.isOpen = false;

                    Inventory.CloseInventory();
                }
            }

            MovementInventory();

            if (Inputs.Accept)
            {
                OpenUsesMenu();
            }
        }


        
    }

    void MovementInventory()
    {
        if (Inputs.Movement_x > 0.5)
        {
            ItemsPos++;
        }

        if (Inputs.Movement_x < -0.5)
        {
            ItemsPos--;
        }

        if (Inputs.Movement_y > 0.5)
        {
            ItemsPos -= 5;
        }

        if (Inputs.Movement_y < -0.5)
        {
            ItemsPos += 5;
        }

        ItemsPos = Mathf.Clamp(ItemsPos, 0, Items.Length - 1);
        ResetInventoryPos();
    }

    public void ResetInventoryPos()
    {
        ItemsSel.transform.parent = Items[ItemsPos].transform;
        ItemsSel.transform.position = Items[ItemsPos].transform.position;

        Inputs.Movement_x = 0;
        Inputs.Movement_y = 0;
    }

    public void OpenUsesMenu()
    {
        if (Items[ItemsPos].GetComponentInChildren<Scr_InventoryButtonData>().Data != Inventory.ObjNull)
        {
            Inventory.isUses = true;
            Inputs.Accept = false;

            Inventory.ButtonChange.SetActive(true);

            Inventory.ButtonEquip.SetActive(false);
            Inventory.ButtonDesEquip.SetActive(false);

            Inventory.Uses[2] = Inventory.ButtonChange;
            Inventory.ResetUsesPos();

            Inventory.UsesMenu.transform.position = ItemsSel.transform.parent.position + (Vector3.right * 50f);
            Inventory.UsesMenu.SetActive(true);

        }
        
    }
}
