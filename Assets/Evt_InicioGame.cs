using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evt_InicioGame : MonoBehaviour
{
    public Scr_Subtitulos Subtitulos;
    public Scr_SubtitulosTuto SubTuto;

    public Scr_PlayerMovement Player;

    public bool Activate = false;
    public bool LastTextOff = false;



    public AudioSource PuertaGolpes;
    public Collider Colider;




    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlayGolpes",7);
    }

    // Update is called once per frame
    void Update()
    {
        if (Activate)
        {
            //Player.isLock = true;

            PuertaGolpes.Stop();

            if (Subtitulos.Sub_Text.Count == 0 && SubTuto.Sub_Text.Count == 0)
            {
                LastTextOff = true;
                Subtitulos.SaveSubtitle("David!", 4f);
                Subtitulos.SaveSubtitle("Calmate Raul estoy bien", 3f);
                Subtitulos.SaveSubtitle("Joder, te oí gritar por el walkie y he subido corriendo, aunque la puerta ahora está bloqueada.", 5f);
                Subtitulos.SaveSubtitle("De acuerdo, ves rápido.", 5f);
                Subtitulos.SaveSubtitle("Sobre todo no te metas en problemas.", 5f);

                Subtitulos.isOn = true;
                Subtitulos.TextDone = true;

                //Invoke("CancelLock", 10f);

                Activate = false;
                var Collider = GetComponent<Collider>().enabled = false;
            }

        }

    }

    void CancelLock()
    {
        Player.isLock = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Activate = true;
        }
    }


    void PlayGolpes()
    {
        PuertaGolpes.Play();
        Colider.enabled = true;
    }
}
