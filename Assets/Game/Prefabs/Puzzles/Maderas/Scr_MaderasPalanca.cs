using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MaderasPalanca : MonoBehaviour
{
    public bool Locked;

    public Scr_InteractiveObject UsingObject;
    public Scr_InputSystem Inputs;

    public GameObject HandObject;

    GameObject ObjectInHand;
    Rigidbody Rb;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        ObjectInHand = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (UsingObject.PrimaryAction == true)
        {
            //Colocar su data en la data del primer hueco vacio.
            Inputs.ActionOne = false;             

            if (HandObject.transform.childCount == 1)
            {
                ObjectInHand = HandObject.transform.GetChild(0).gameObject;

                if (ObjectInHand.GetComponent<Scr_EQ_Palanca>())
                {
                    //Animacion de llave
                    ObjectInHand.transform.parent = gameObject.transform;

                    ObjectInHand.transform.localPosition = Vector3.forward * -0.50f;
                    ObjectInHand.transform.localRotation = Quaternion.Euler(Vector3.right * 90f);

                    UsingObject.gameObject.GetComponent<Collider>().enabled = false;

                    Invoke("Abrir", 1f);


    }   }   }   }        

    void Abrir()
    {
        ObjectInHand.transform.parent = HandObject.transform;
        ObjectInHand.transform.position = HandObject.transform.position;
        ObjectInHand.transform.rotation = HandObject.transform.rotation;

        //Puerta Abierta
        Locked = false;

        //Se aplica la gravedad
        Rb.isKinematic = false;
    }
}
