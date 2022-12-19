using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;



public class Scr_EQ_Monoculo : MonoBehaviour
{
    public bool isActive;
    public Scr_EquipedObject Object;

    private GameObject HandObject;

    public Volume Effects;
    Vignette Vineta;

    // Start is called before the first frame update
    void Awake()
    {
        Effects.sharedProfile.TryGet<Vignette>(out Vineta);
    }

    // Update is called once per frame
    void Update()
    {
        if (Object.PrimaryAction)
        {
            if(!isActive)
            StartAnimation();
        }
        else
        {
            EndAnimation();
        }
    }

    void StartAnimation()
    {
        isActive = true;

        HandObject = gameObject.transform.parent.gameObject;

        gameObject.transform.parent = HandObject.transform.parent;
        gameObject.transform.localPosition = gameObject.transform.localPosition + (Vector3.up * 1);

        Invoke("VinetaOn", 0.5f);


    }

    void EndAnimation()
    {
        isActive = false;

        gameObject.transform.parent = HandObject.transform;
        gameObject.transform.localPosition = Vector3.zero;

        CancelInvoke("VinetaOn");
        VinetaOff();
    }











    //Pantalla Vineta

    void VinetaOn()
    {
        Vineta.active = true;
    }

    void VinetaOff()
    {
        Vineta.active = false;
    }
}
