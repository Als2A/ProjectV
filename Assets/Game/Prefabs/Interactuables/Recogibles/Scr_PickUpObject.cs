using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PickUpObject : MonoBehaviour
{
    [Header("Referencias")]
    public Scr_ScripteableInventory ObjectData;
    [Space]
    public Scr_InteractiveObject UsingObject;
    public Scr_InputSystem Inputs;
    public Scr_Inventory Inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UsingObject.PrimaryAction == true)
        {
            //Colocar su data en la data del primer hueco vacio.
            Inputs.ActionOne = false;

            for (int i = 1; i < Inventory.Items.Length; i++)
            {
                var ButtonData = Inventory.Items[i].GetComponentInChildren<Scr_InventoryButtonData>();

                if(ButtonData.Data.id == 0)
                {
                    ButtonData.Data = ObjectData;
                    Inventory.Items[i].GetComponentInChildren<Scr_InventoryButtonData>().UpdateSlot();

                    Destroy(gameObject);

                    break;
                }     
                
                if (i == Inventory.Items.Length -1 && ButtonData.Data.id != 0)
                {
                    Debug.Log("Estas lleno my G");
                }
            }


        }
    }
}
