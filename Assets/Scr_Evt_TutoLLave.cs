using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Evt_TutoLLave : MonoBehaviour
{
    public Scr_Subtitulos Subtitulos;
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
            //Animacion llave



            //Personaje Hablando
            Invoke("Voices", 1f);



            Activate = false;
        }

    }

    void Voices()
    {
        Subtitulos.SaveSubtitle("Esto esta dando mal rollo", 4f);

        Subtitulos.isOn = true;
        Subtitulos.TextDone = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Activate = true;
        }
    }
}
