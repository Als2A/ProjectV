using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Evt_TutoInteract : MonoBehaviour
{
    public Scr_Subtitulos Subtitulos;
    public Scr_SubtitulosTuto SubTuto;

    public Scr_PlayerMovement Player;

    public bool Activate = false;
    public bool LastTextOff = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        if (Activate)
        {
            Player.isLock = true;

            if (Subtitulos.Sub_Text.Count == 0 && SubTuto.Sub_Text.Count == 0)
            {
                LastTextOff = true;
                Subtitulos.SaveSubtitle("La puerta está abierta", 3f);
                Subtitulos.SaveSubtitle("No te preocupes", 2f);
                Subtitulos.SaveSubtitle("entra y si necesitas ayuda avisame por el walkie", 3f);

                Subtitulos.isOn = true;
                Subtitulos.TextDone = true;



                Invoke("CancelLock", 6f);

                Invoke("subtitulosTuto", 8f);

                Activate = false;
                var Collider = GetComponent<Collider>().enabled = false;
            }

        }

    }

    void CancelLock()
    {
        Player.isLock = false;
    }

    void subtitulosTuto()
    {
        SubTuto.SaveSubtitle("Pulsa [Right Click] para interactuar rapido", 3f);
        SubTuto.SaveSubtitle("Pulsa [Left Click] y mueve el [Mouse] para interactuar poco a poco", 3f);

        SubTuto.isOn = true;
        SubTuto.TextDone = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Activate = true;
        }
    }
}
