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
                Subtitulos.SaveSubtitle("La puerta está abierta", 4f);
                Subtitulos.SaveSubtitle("No te preocupes", 3f);
                Subtitulos.SaveSubtitle("entra y si necesitas ayuda avisame por el walkie", 5f);

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
