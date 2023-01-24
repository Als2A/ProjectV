using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Evt_TutoInteract : MonoBehaviour
{
    public Scr_Subtitulos Subtitulos;

    public Scr_PlayerMovement Player;

    public bool Activate = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Activate)
        {
            Subtitulos.SaveSubtitle("La puerta está abierta", 4f);
            Subtitulos.SaveSubtitle("No te preocupes", 3f);
            Subtitulos.SaveSubtitle("entra y si necesitas ayuda avisame por el walkie", 5f);

            Subtitulos.isOn = true;
            Subtitulos.TextDone = true;

            Player.isLock = true;

            Invoke("CancelLock", 10f);

            Activate = false;
            var Collider = GetComponent<Collider>().enabled = false;
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
}
