using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;



public class Scr_EQ_Monoculo : MonoBehaviour
{
    public bool isActive;
    public Scr_EquipedObject Object;

    public Scr_BlackFade BlackFade;

    public GameObject HandObject;

    public Vector3 DesiredPos;

    public Volume Effects;
    public Vignette Vineta;

    // Start is called before the first frame update
    void Start()
    {
        Effects.sharedProfile.TryGet<Vignette>(out Vineta);
        HandObject = gameObject.transform.parent.gameObject;
        BlackFade = GameObject.Find("BlackFade").GetComponent<Scr_BlackFade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Object.PrimaryAction)
        {            
            StartAnimation();            
        }
        else if (!Object.PrimaryAction)
        {
            EndAnimation();            
        }
    }

    void StartAnimation()
    {
        //Start Fade        
        MonoculoFadeOn();

        //Move Object
        gameObject.transform.parent = HandObject.transform.parent;
        gameObject.transform.localPosition = Vector3.zero + (Vector3.forward * 0.05f);

        //Open Vintege
        Invoke("VinetaOn", 0.5f);
        Invoke("MonoculoFadeOff", 1f);
    }














    void EndAnimation()
    {
        //Start Fade        
        MonoculoFadeOn();

        //Return Object
        gameObject.transform.parent = HandObject.transform;
        gameObject.transform.localPosition = Vector3.zero;

        //Vintagge
        CancelInvoke("VinetaOn");
        CancelInvoke("MonoculoFadeOff");

        MonoculoFadeOff();



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
}
