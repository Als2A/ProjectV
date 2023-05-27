using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Evt_TutoLLave : MonoBehaviour
{
    public Scr_Subtitulos Subtitulos;
    public bool Activate = false;

    public Rigidbody KeyRB;

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
            //Animacion llave
            KeyRB.isKinematic = false;


            //Personaje Hablando
            Invoke("Voices", 1f);



            Activate = false;
            var Collider = GetComponent<Collider>().enabled = false;
        }

    }

    void Voices()
    {
        Subtitulos.SaveSubtitle("Esto no es muy normal...", 2f, Voces[0]);

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
