using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scr_PickUpObject : MonoBehaviour
{
    [Header("Referencias")]
    public Scr_ScripteableInventory ObjectData;
    [Space]
    public Scr_InteractiveObject UsingObject;
    public Scr_InputSystem Inputs;
    public Scr_Inventory Inventory;

    public AudioSource Audio;

    private Transform PlayerCam;
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

                    Audio.Play();

                    PlayerCam = GameObject.Find("PlayerCamera").transform;
                    transform.DOMove(PlayerCam.position + (Vector3.down * 0.25f), 0.2f);
                    transform.DOScale(transform.localScale * 0.6f, 0.2f);

                    Destroy(gameObject,0.5f);

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
