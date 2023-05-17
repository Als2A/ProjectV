using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_FinalSubtitles : MonoBehaviour
{
    public Scr_Subtitulos Subtitulos;
    public Scr_SubtitulosTuto SubTuto;

    public Scr_PlayerMovement Player;

    public bool Activate = false;
    public bool LastTextOff = false;

    //public AudioSource PuertaGolpes;
    public Collider Colider;

    public AudioClip[] Voces;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Activate)
        {
            //Player.isLock = true;

            //PuertaGolpes.Stop();

            if (Subtitulos.Sub_Text.Count == 0 && SubTuto.Sub_Text.Count == 0)
            {
                Activate = false;
                var Collider = GetComponent<Collider>().enabled = false;

                LastTextOff = true;
                Subtitulos.SaveSubtitle("David!", 4f, Voces[0]);


                Subtitulos.isOn = true;
                Subtitulos.TextDone = true;

                //Invoke("CancelLock", 10f);


            }

        }
    }
}
