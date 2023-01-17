using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Baul : MonoBehaviour
{
    public bool isOpen;
    public GameObject ChestCanvas;

    public Scr_Inventory Player_Inventory;

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

            ChestCanvas.SetActive(true);

            Cursor.lockState = CursorLockMode.None;

            Inputs.Inputs.SwitchCurrentActionMap("Menu");
        }
    }
}
