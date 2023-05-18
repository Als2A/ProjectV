using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_FinalSubtitles : MonoBehaviour
{
    public Scr_Subtitulos Subtitulos;
    public Scr_SubtitulosTuto SubTuto;

    public bool Activate = false;
    public bool LastTextOff = false;

    //public AudioSource PuertaGolpes;
    //public Collider Colider;

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
                //var Collider = GetComponent<Collider>().enabled = false;

                LastTextOff = true;
                Subtitulos.SaveSubtitle("Que Cojones esta pasando Aqui?", 2f, Voces[0]);
                Subtitulos.SaveSubtitle(" ", 1f, Voces[1]);
                Subtitulos.SaveSubtitle("Creo que con eso ya sera suficiente", 2f, Voces[2]);
                Subtitulos.SaveSubtitle("Yo creo que no", 2f, Voces[3]);

                Subtitulos.isOn = true;
                Subtitulos.TextDone = true;

                //Invoke("CancelLock", 10f);


            }

        }
    }
}
