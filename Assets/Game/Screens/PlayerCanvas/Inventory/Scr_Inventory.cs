using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Scr_Inventory : MonoBehaviour
{
    [Header("Referencias")]
    public Scr_InputSystem Inputs;
    public Scr_PlayerMovement Movement;
    [Space]
    public GameObject Hand;

    public CanvasGroup InventoryAlpha;

    public Scr_InteractivePlayer InteractivePlayer;

    public Scr_EquipedPlayer EquipPlayer;

    public GameObject ButtonEquip;
    public GameObject ButtonDesEquip;
    public GameObject ButtonChange;

    public Scr_BlurUI Blur;

    [Header("Text Inventory")]
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Body;

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

    [Header("Chest")]
    public Scr_Baul Chest;
    public Scr_InventoryChest InventoryChest;



    [Header("Inspector 3D")]
    public GameObject ViewerSet;
    public GameObject ViewerTexture;
    public GameObject InspectorObject;
    public GameObject InspectorRotatingObject;

    [Header("Audios")]
    public AudioSource Aud_Open;
    public AudioSource Aud_Move;
    public AudioSource Aud_OK;



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

                    Aud_Open.pitch = (Random.Range(0.9f, 1.2f));
                    Aud_Open.Play();

                    InventoryAlpha.DOFade(1f, 0.5f);

                    Movement.isWalking = false;
                    Movement.isSprinting = false;

                    InteractivePlayer.STOP = true;

                    Inputs.OpenInventory = false;

                    ItemsMenu.SetActive(true);
                    ItemsSel.SetActive(true);

                    MenuInventoryIsOpen = true;
                    
                    Cursor.lockState = CursorLockMode.None;

                    Inputs.Inputs.SwitchCurrentActionMap("Menu");
                }
            }
        }

        if (Inputs.Inputs.currentActionMap == Inputs.UiMap && Chest.isOpen)
        {

        }
        
        if (Inputs.Inputs.currentActionMap == Inputs.UiMap && MenuInventoryIsOpen) // -- Player Inventory  -- //
        {

            if (isSee) // -- Inspector 3D Update --  //
            {
                if (Inputs.OpenInventory || Inputs.Cancel)
                {
                    CloseSeeMenu();
                }
            }
            else if(isCombining) // -- Combine Update --  //
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
            else if (!isUses && !Chest.isOpen) // -- Inventory Update -- //
            {
                if (Inputs.OpenInventory || Inputs.Cancel)
                {
                    if (ItemsMenu.activeSelf)
                    {
                        CloseInventory();                   
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

        DrawObjectInfo();
    }










    void DrawObjectInfo()
    {        
        
            var ButtonData = Items[ItemsPos].GetComponentInChildren<Scr_InventoryButtonData>();

            Title.text = ButtonData.Data.Name;
            Body.text = ButtonData.Data.Descripcion;
        

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

    public void ResetUsesPos()
    {
        UsesSel.transform.parent = Uses[UsesPos].transform;
        UsesSel.transform.position = Uses[UsesPos].transform.position;

        Inputs.Movement_y = 0;        
    }


    public void OpenUsesMenu()
    {
        if(!Chest.isOpen)
        {
            if (!isSee && !isCombining)
            {
                if (Items[ItemsPos].GetComponentInChildren<Scr_InventoryButtonData>().Data != ObjNull)
                {
                    isUses = true;
                    Inputs.Accept = false;

                    if (ItemsPos == 0)
                    {
                        ButtonEquip.SetActive(false);
                        ButtonDesEquip.SetActive(true);

                        ButtonChange.SetActive(false);

                        Uses[2] = ButtonDesEquip;
                        ResetUsesPos();
                    }
                    else
                    {
                        ButtonEquip.SetActive(true);
                        ButtonDesEquip.SetActive(false);

                        ButtonChange.SetActive(false);

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
        else if(Chest.isOpen && ItemsSel.activeInHierarchy)
        {
            if (Items[ItemsPos].GetComponentInChildren<Scr_InventoryButtonData>().Data != ObjNull)
            {
                isUses = true;
                Inputs.Accept = false;

                ButtonChange.SetActive(true);

                ButtonEquip.SetActive(false);
                ButtonDesEquip.SetActive(false);

                Uses[2] = ButtonChange;
                ResetUsesPos();

                UsesMenu.transform.position = ItemsSel.transform.parent.position + (Vector3.right * 50f);
                UsesMenu.SetActive(true);
                
            }
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

    public void ChangeItem()
    {
        if(ItemsSel.activeInHierarchy)
        {
            for (int i = 0; i < InventoryChest.Items.Length; i++)
            {
                var ButtonData = InventoryChest.Items[i].GetComponentInChildren<Scr_InventoryButtonData>();

                if (ButtonData.Data.id == 0)
                {

                    Debug.Log("Change");

                    var ItemA_Data = Items[ItemsPos].GetComponentInChildren<Scr_InventoryButtonData>();
                    var ItemB_Data = InventoryChest.Items[i].GetComponentInChildren<Scr_InventoryButtonData>();
                    
                    var ItemS_Data = ItemA_Data.Data;

                    ItemA_Data.Data = ItemB_Data.Data;
                    ItemB_Data.Data = ItemS_Data;

                    ItemA_Data.UpdateSlot();
                    ItemB_Data.UpdateSlot();        
                    

                    break;
                }

                if (i == InventoryChest.Items.Length - 1 && ButtonData.Data.id != 0)
                {
                    Debug.Log("Estas lleno my G");
                }
            }

            CloseUsesMenu();

        }
        
        if (InventoryChest.ItemsSel.activeInHierarchy)
        {
            for (int i = 1; i < Items.Length; i++)
            {
                var ButtonData = Items[i].GetComponentInChildren<Scr_InventoryButtonData>();

                if (ButtonData.Data.id == 0)
                {

                    Debug.Log("Change");

                    var ItemA_Data = InventoryChest.Items[InventoryChest.ItemsPos].GetComponentInChildren<Scr_InventoryButtonData>();
                    var ItemB_Data = Items[i].GetComponentInChildren<Scr_InventoryButtonData>();

                    var ItemS_Data = ItemA_Data.Data;

                    ItemA_Data.Data = ItemB_Data.Data;
                    ItemB_Data.Data = ItemS_Data;

                    ItemA_Data.UpdateSlot();
                    ItemB_Data.UpdateSlot();


                    break;
                }

                Debug.Log("Estas lleno my G");

            }

            CloseUsesMenu();

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

        for (int i = 1; i < Items.Length; i++)
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

            ViewerTexture.GetComponent<CanvasGroup>().DOFade(1, 0.2f).SetEase(Ease.InOutSine);

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
            

            ViewerTexture.GetComponent<CanvasGroup>().DOFade(0,0.2f).SetEase(Ease.InOutSine);
            Invoke("DesactivateInspector3D", 0.2f);
        }
    }

    void DesactivateInspector3D()
    {
        ViewerTexture.SetActive(false);
        ViewerSet.SetActive(false);
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

        var Item_A = Items[CombinePos].GetComponentInChildren<Scr_InventoryButtonData>();
        var Item_B = Items[ItemsPos].GetComponentInChildren<Scr_InventoryButtonData>();


        if (DataCombine.CombineObjectID == Item_B.Data.id || Item_B.Data.CombineObjectID == DataCombine.id)
        {
            if (Item_A.Data.CombinePrimary)
            {
                Item_A.Data.Variant = Item_B.Data.Variant;

                if(Item_B.Data.CombineDestroy)
                { Item_B.Data = ObjNull; }
                else
                {
                    var SaveDataItem = Item_B.Data;
                    Item_B.Data = Item_A.Data.CombineResult;

                    Item_A.Data.CombineResult = SaveDataItem;
                }

            }
            else if (!Item_A.Data.CombinePrimary)
            {
                Item_B.Data.Variant = Item_A.Data.Variant;

                if (Item_A.Data.CombineDestroy)
                { Item_A.Data = ObjNull; }
                else
                {
                    var SaveDataItem = Item_A.Data;
                    Item_A.Data = Item_B.Data.CombineResult;

                    Item_B.Data.CombineResult = SaveDataItem;
                }
            }

            Item_A.UpdateSlot();
            Item_B.UpdateSlot();

            isCombining = false;




        }
        else
        {
            Debug.Log("NoCombinable");
        }
    }

    public void CloseInventory()
    {
        Blur.BlurOff();

        Aud_Open.pitch = (Random.Range(0.9f, 1.2f));
        Aud_Open.Play();

        InventoryAlpha.DOFade(0f, 0.5f);

        MenuInventoryIsOpen = false;

        Inputs.OpenInventory = false;
        Inputs.Cancel = false;

        InteractivePlayer.STOP = false;        

        Cursor.lockState = CursorLockMode.Locked;

        Inputs.Inputs.SwitchCurrentActionMap("Player");

        Invoke("DesactiveInventory", 0.5f);
    }

    void DesactiveInventory()
    {
        ItemsMenu.SetActive(false);
    }

                        
}
