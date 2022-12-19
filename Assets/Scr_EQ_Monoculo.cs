using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;



public class Scr_EQ_Monoculo : MonoBehaviour
{
    public bool isActive;
    public Scr_EquipedObject Object;

    public GameObject BlackFade;

    public GameObject HandObject;

    public Vector3 DesiredPos;

    public Volume Effects;
    public Vignette Vineta;

    // Start is called before the first frame update
    void Start()
    {
        Effects.sharedProfile.TryGet<Vignette>(out Vineta);
        HandObject = gameObject.transform.parent.gameObject;
        BlackFade = GameObject.Find("BlackFade");
    }

    // Update is called once per frame
    void Update()
    {
        if (Object.PrimaryAction)
        {
            //if(!isActive)
            StartAnimation();

            BlackFade.GetComponent<Scr_BlackFade>().FadingOn();

            Debug.Log("Monoculo");
        }
        else if (!Object.PrimaryAction)
        {
            EndAnimation();
        }
    }

    void StartAnimation()
    {
        VinetaOn();

        gameObject.transform.parent = HandObject.transform.parent;
        gameObject.transform.localPosition = Vector3.zero + (Vector3.forward * 0.05f);

        Invoke("VinetaOn", 0.5f);
    }

    void EndAnimation()
    {
        gameObject.transform.parent = HandObject.transform;
        gameObject.transform.localPosition = Vector3.zero;

        CancelInvoke("VinetaOn");
        VinetaOff();
    }











    //Pantalla Vineta

    void VinetaOn()
    {
        Vineta.active = true;
        BlackFade.GetComponent<Scr_BlackFade>().FadingOff();
    }

    void VinetaOff()
    {
        Vineta.active = false;
    }
}
