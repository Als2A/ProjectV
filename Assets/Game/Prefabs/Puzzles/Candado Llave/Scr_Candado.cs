using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Candado : MonoBehaviour
{
    public bool Locked;
    public int KeyOpen;

    public Scr_InteractiveObject UsingObject;
    public Scr_InputSystem Inputs;
    public Scr_Puerta Puerta;

    public GameObject HandObject;
    public Rigidbody Rb;

    public Scr_Inventory Inventory;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UsingObject.PrimaryAction == true)
        {
            //Colocar su data en la data del primer hueco vacio.
            Inputs.ActionOne = false;

            GameObject ObjectInHand = null;

            if (HandObject.transform.childCount == 1)
            {
                ObjectInHand = HandObject.transform.GetChild(0).gameObject;

                if (ObjectInHand.GetComponent<Scr_Key>().DoorToOpen == KeyOpen)
                {
                    //Animacion de llave
                    ObjectInHand.transform.parent = gameObject.transform;

                    ObjectInHand.transform.localPosition = Vector3.forward * -0.05f;
                    ObjectInHand.transform.localRotation = Quaternion.Euler(Vector3.right * 90f);


                    //Puerta Abierta
                    Locked = false;
                    Puerta.Locked = false;
                    Puerta.ResetFollowPos();


                    //Se aplica la gravedad
                    Rb.isKinematic = false;


                    //Borrar Item del Inventario
                    var ButtonData = Inventory.Items[0].GetComponentInChildren<Scr_InventoryButtonData>();

                    ButtonData.Data = ButtonData.DataNull;
                    ButtonData.UpdateSlot();

                }
            }
                




        }
    }
}
