using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Inventory : MonoBehaviour
{
    [Header("Referencias")]
    public Scr_InputSystem Inputs;
    public Scr_PlayerMovement Movement;
    [Space]
    public GameObject Hand;

    public Scr_EquipedPlayer EquipPlayer;

    public GameObject ButtonEquip;
    public GameObject ButtonDesEquip;

    public Scr_BlurUI Blur;

    [Header("Estados")]
    public bool MenuInventoryIsOpen;

    [Header("Menu de Items")]
    public int ItemsPos = 0;    
    [Space]
    public GameObject ItemsMenu;
    public GameObject ItemsSel;
    [Space]
    public GameObject[] Items;
    [Space]

    [Header("Menu de Usos")]
    public bool isUses = false;
    public bool isSee = false;
    public int UsesPos = 0;
    [Space]
    public GameObject UsesMenu;
    public GameObject UsesSel;
    [Space]
    public GameObject[] Uses;
    [Space]
    public Scr_ScripteableInventory ObjNull;
    [Space]
    //Combine
    public bool isCombining;
    public Scr_ScripteableInventory DataCombine;
    public int CombinePos;



    [Header("Inspector 3D")]
    public GameObject ViewerSet;
    public GameObject ViewerTexture;
    public GameObject InspectorObject;
    public GameObject InspectorRotatingObject;


    // Start is called before the first frame update
    void Start()
    {
        ItemsMenu.SetActive(true);
        ItemsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // -- Open Menu --

        if (Inputs.Inputs.currentActionMap == Inputs.PlayerMap)
        {
            if (Inputs.OpenInventory)
            {
                if (!ItemsMenu.activeSelf)
                {
                    Blur.BlurOn(1f);

                    Movement.isWalking = false;
                    Movement.isSprinting = false;

                    Inputs.OpenInventory = false;

                    ItemsMenu.SetActive(true);

                    MenuInventoryIsOpen = true;
                    
                    Cursor.lockState = CursorLockMode.None;

                    Inputs.Inputs.SwitchCurrentActionMap("Menu");
                }
            }
        }


        
        if (Inputs.Inputs.currentActionMap == Inputs.UiMap && MenuInventoryIsOpen)
        {

            if (isSee) // -- Inspector 3D Update --  //
            {
                if (Inputs.OpenInventory || Inputs.Cancel)
                {
                    CloseSeeMenu();
                }
            }
            else if(isCombining)
            {
                if (Inputs.OpenInventory || Inputs.Cancel)
                {
                    isCombining = false;

                    Inputs.OpenInventory = false;
                    Inputs.Cancel = false;
                }

                MovementInventory();

                if (Inputs.Accept)
                {
                    CombineAction();
                }


            }
            else if (!isUses) // -- Inventory Update -- //
            {
                if (Inputs.OpenInventory || Inputs.Cancel)
                {
                    if (ItemsMenu.activeSelf)
                    {
                        Blur.BlurOff();

                        MenuInventoryIsOpen = false;

                        Inputs.OpenInventory = false;
                        Inputs.Cancel = false;

                        ItemsMenu.SetActive(false);
                        
                        Cursor.lockState = CursorLockMode.Locked;

                        Inputs.Inputs.SwitchCurrentActionMap("Player");

                        
                    }
                }

                MovementInventory();

                if (Inputs.Accept && isUses == false )
                {
                    OpenUsesMenu();
                }

            }
            else if (isUses) // -- Uses Update -- //
            {
                if (Inputs.OpenInventory || Inputs.Cancel)
                {
                    CloseUsesMenu();
                }

                MovementUses();



                if (ItemsPos <= 1 && Inputs.Accept && UsesPos == 2)  // -- DeEquip -- // 
                {
                    Inputs.Accept = false;

                    DeUsesEquip();
                }
                else if (ItemsPos >= 2 && Inputs.Accept && UsesPos == 2)  // -- Equip -- // 
                {
                    Inputs.Accept = false;

                    UsesEquip();
                }

                if (Inputs.Accept && UsesPos == 1)  // -- See -- // 
                {
                    Inputs.Accept = false;

                    OpenSeeMenu();
                }

                if (Inputs.Accept && UsesPos == 0)  // -- Combine -- // 
                {
                    Inputs.Accept = false;

                    CombineObject();
                }


            }




        }
    }













    void MovementInventory()
    { 
        if(Inputs.Movement_x > 0.5)
        {
            ItemsPos++;            
        }

        if (Inputs.Movement_x < -0.5)
        {
            ItemsPos--;            
        }

        if (Inputs.Movement_y > 0.5)
        {
            
            if      (ItemsPos <= 1) {  /*Nothing*/   }
            else if (ItemsPos == 2) { ItemsPos = 0;  }
            else                    { ItemsPos -= 3; }       
        }

        if (Inputs.Movement_y < -0.5)
        {
            if (ItemsPos >= 8) { /*Nothing*/ }
            else { ItemsPos += 3; }           
        }

        ItemsPos = Mathf.Clamp(ItemsPos, 0, Items.Length-1);
        ResetInventoryPos();
    }

    void ResetInventoryPos()
    {
        ItemsSel.transform.parent = Items[ItemsPos].transform;
        ItemsSel.transform.position = Items[ItemsPos].transform.position;

        Inputs.Movement_x = 0;
        Inputs.Movement_y = 0;        
    }

    void MovementUses()
    {
        if (Inputs.Movement_y > 0.5)
        {
            UsesPos++;
            
        }

        if (Inputs.Movement_y < -0.5)
        {
            UsesPos--;
            
        }

        UsesPos = Mathf.Clamp(UsesPos, 0, 2);
        ResetUsesPos();
    }

    void ResetUsesPos()
    {
        UsesSel.transform.parent = Uses[UsesPos].transform;
        UsesSel.transform.position = Uses[UsesPos].transform.position;

        Inputs.Movement_y = 0;        
    }


    public void OpenUsesMenu()
    {
        if(!isSee && !isCombining)
        {
            if (Items[ItemsPos].GetComponentInChildren<Scr_InventoryButtonData>().Data != ObjNull)
            {
                isUses = true;
                Inputs.Accept = false;

                if (ItemsPos <= 1)
                {
                    ButtonEquip.SetActive(false);
                    ButtonDesEquip.SetActive(true);

                    Uses[2] = ButtonDesEquip;
                    ResetUsesPos();
                }
                else
                {
                    ButtonEquip.SetActive(true);
                    ButtonDesEquip.SetActive(false);

                    Uses[2] = ButtonEquip;
                    ResetUsesPos();
                }

                UsesMenu.transform.position = ItemsSel.transform.parent.position + (Vector3.right * 50f);
                UsesMenu.SetActive(true);
            }
        }
        else if (isCombining)
        {
            CombineAction();
        }
    }

    public void CloseUsesMenu()
    {
        if (isUses)
        {
            isUses = false;

            Inputs.OpenInventory = false;
            Inputs.Cancel = false;

            UsesMenu.SetActive(false);
        }
    }

    public void UsesEquip()
    {
        Debug.Log("Equip");

        //Variables
        var Item0_Data = Items[0].GetComponentInChildren<Scr_InventoryButtonData>();
        var ItemPos_Data = Items[ItemsPos].GetComponentInChildren<Scr_InventoryButtonData>();

        var SavedData = Item0_Data.Data;

        //Set Data
        Item0_Data.Data = ItemPos_Data.Data;
        ItemPos_Data.Data = SavedData;

        //Update Images
        Item0_Data.UpdateSlot();
        ItemPos_Data.UpdateSlot();

        //Action
        if (Hand.transform.childCount == 1) { Destroy(Hand.transform.GetChild(0).gameObject); }

        Instantiate(Item0_Data.Data.Object_Prefab, Hand.transform.position, Hand.transform.rotation, Hand.transform);

        Invoke("DoEquipPlayer", 0.1f);



        CloseUsesMenu();
    }

    void DoEquipPlayer()
    {
        EquipPlayer.Object = Hand.transform.GetChild(0).gameObject.GetComponent<Scr_EquipedObject>();
    }

    public void DeUsesEquip()
    {
        Debug.Log("DeEquip");

        //Variables
        var Item0_Data = Items[0].GetComponentInChildren<Scr_InventoryButtonData>();

        for (int i = 2; i < Items.Length; i++)
        {
            var ButtonData = Items[i].GetComponentInChildren<Scr_InventoryButtonData>();

            if (ButtonData.Data.id == 0)
            {
                ButtonData.Data = Item0_Data.Data;
                Item0_Data.Data = ButtonData.DataNull;

                Item0_Data.UpdateSlot();
                Items[i].GetComponentInChildren<Scr_InventoryButtonData>().UpdateSlot();

                Destroy(Hand.transform.GetChild(0).gameObject);
                break;
            }

            if (i == Items.Length - 1 && ButtonData.Data.id != 0)
            {
                Debug.Log("Estas lleno my G");
            }
        }


        CloseUsesMenu();
    }

    public void OpenSeeMenu()
    {
        Debug.Log("Inspector");

        if (!isSee && !isCombining)
        {
            isSee = true;
            Destroy(InspectorRotatingObject.transform.GetChild(0).gameObject);
            Instantiate(Items[ItemsPos].GetComponentInChildren<Scr_InventoryButtonData>().Data.Object_Prefab,
                        InspectorObject.transform.position, InspectorObject.transform.rotation, InspectorRotatingObject.transform);

            InspectorRotatingObject.transform.localScale = Vector3.one * Items[ItemsPos].GetComponentInChildren<Scr_InventoryButtonData>().Data.InspectorScale;

            ViewerTexture.SetActive(true);
            ViewerSet.SetActive(true);

            CloseUsesMenu();
        }


    }

    void CloseSeeMenu()
    {
        if (isSee)
        {
            Inputs.OpenInventory = false;
            Inputs.Cancel = false;

            isSee = false;
            ViewerTexture.SetActive(false);
            ViewerSet.SetActive(false);
        }
    }


    public void CombineObject()
    {
        Debug.Log("Combine");

        if (!isCombining)
        {
            isCombining = true;

            DataCombine = Items[ItemsPos].GetComponentInChildren<Scr_InventoryButtonData>().Data;

            CombinePos = ItemsPos;

            CloseUsesMenu();
        }
    }

    void CombineAction()
    {
        Inputs.Accept = false;

        var DataItemPos = Items[CombinePos].GetComponentInChildren<Scr_InventoryButtonData>();
        var ItemPos_Data = Items[ItemsPos].GetComponentInChildren<Scr_InventoryButtonData>();


        if (DataCombine.CombineObjectID == ItemPos_Data.Data.id || ItemPos_Data.Data.CombineObjectID == DataCombine.id)
        {
            if (DataItemPos.Data.CombinePrimary)
            {
                DataItemPos.Data.Variant = ItemPos_Data.Data.Variant;

                if(ItemPos_Data.Data.CombineDestroy)
                { ItemPos_Data.Data = ObjNull; }
                else
                {
                    var SaveDataItem = ItemPos_Data.Data;
                    ItemPos_Data.Data = DataItemPos.Data.CombineResult;

                    DataItemPos.Data.CombineResult = SaveDataItem;
                }

            }

            ItemPos_Data.UpdateSlot();

            isCombining = false;




        }
        else
        {
            Debug.Log("NoCombinable");
        }
    }
}
