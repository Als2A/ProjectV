using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;



public class Scr_EQ_Monoculo : MonoBehaviour
{
    public bool isActive;
    public Scr_EquipedObject Object;

    public Scr_BlackFade BlackFade;

    public GameObject HandObject;

    public Vector3 DesiredPos;

    public Volume Effects;
    public Vignette Vineta;

    public Scr_ScripteableInventory Data;
    public Scr_Inventory Inventory;

    public GameObject MonoculoScreens;
    public Sprite[] MonoculoSprites;
    

    // Start is called before the first frame update
    void Start()
    {
        Effects.sharedProfile.TryGet<Vignette>(out Vineta);
        HandObject = gameObject.transform.parent.gameObject;
        BlackFade = GameObject.Find("BlackFade").GetComponent<Scr_BlackFade>();

        MonoculoScreens = GameObject.Find("MonoculoScreens");
        Inventory = GameObject.Find("Inventory_Logic").GetComponent<Scr_Inventory>();
        Data = GameObject.Find("Inventory_Logic").GetComponentInChildren<Scr_Inventory>().Items[0].GetComponentInChildren<Scr_InventoryButtonData>().Data;
    }

    // Update is called once per frame
    void Update()
    {
        if (Object.PrimaryAction && !Inventory.MenuInventoryIsOpen)
        {    
            if(isActive)
            StartAnimation();            
        }
        else if (!Object.PrimaryAction)
        {
            EndAnimation();            
        }

        MonoculoScreens.transform.GetChild(0).GetComponentInChildren<Image>().sprite = MonoculoSprites[((int)Data.Variant)];
    }

    void StartAnimation()
    {
        isActive = false;

        //Move Object
        gameObject.transform.parent = HandObject.transform.parent;
        gameObject.transform.localPosition = Vector3.zero + (Vector3.forward * 0.05f);

        //Open Vintege
        Invoke("VinetaOn", 0.2f);
        //Invoke("MonoculoFadeOff", 1f);
    }














    void EndAnimation()
    {
        isActive = true;

        //Return Object
        gameObject.transform.parent = HandObject.transform;
        gameObject.transform.localPosition = Vector3.zero;

        //Vintagge
        CancelInvoke("VinetaOn");
        VinetaOff();
    }











    //Pantalla Vineta

    void VinetaOn()
    {
        Vineta.active = true;

        MonoculoScreens.transform.GetChild(0).gameObject.SetActive(true);
        MonoculoScreens.transform.GetChild(1).gameObject.SetActive(true);


        HandObject.transform.parent.parent.GetComponentInChildren<Scr_HandBobCam>().isLock = true;
        HandObject.transform.parent.parent.GetComponentInChildren<Scr_HandBobCam>().BobTimer = 0;
    }

    void VinetaOff()
    {
        Vineta.active = false;

        MonoculoScreens.transform.GetChild(0).gameObject.SetActive(false);
        MonoculoScreens.transform.GetChild(1).gameObject.SetActive(false);

        HandObject.transform.parent.parent.GetComponentInChildren<Scr_HandBobCam>().isLock = false;
    }

    /*
    void MonoculoFadeOff()
    {
        BlackFade.Speed = 9;

        BlackFade.FadeOff = true;
        BlackFade.FadeOn = false;
    }

    void MonoculoFadeOn()
    {
        BlackFade.Speed = 9;

        BlackFade.FadeOff = false;
        BlackFade.FadeOn = true;
    }
    */
}
