using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Baul : MonoBehaviour
{
    public bool isOpen;
    public GameObject ChestCanvas;

    public Scr_Inventory Player_Inventory;
    public Scr_InventoryChest Chest_Inventory;

    private Scr_InteractiveObject Logic;

    public Scr_InputSystem Inputs;


    // Start is called before the first frame update
    void Start()
    {
        Logic = GetComponentInChildren<Scr_InteractiveObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Logic.PrimaryAction && !isOpen)
        {
            isOpen = true;

            Inputs.ActionOne = false;

            Player_Inventory.ItemsMenu.SetActive(true);

            Player_Inventory.MenuInventoryIsOpen = true;

            Player_Inventory.GetComponent<CanvasGroup>().alpha = 1;
            ChestCanvas.SetActive(true);

            Player_Inventory.ItemsSel.SetActive(false);
            Chest_Inventory.ItemsSel.SetActive(true);

            Chest_Inventory.ItemsPos = 0;

            Chest_Inventory.ResetInventoryPos();

            Cursor.lockState = CursorLockMode.None;

            Inputs.Inputs.SwitchCurrentActionMap("Menu");
        }
    }
}
