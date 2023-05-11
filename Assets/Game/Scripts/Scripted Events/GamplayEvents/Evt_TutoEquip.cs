using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evt_TutoEquip : MonoBehaviour
{
    public Scr_Subtitulos Subtitulos;
    public Scr_SubtitulosTuto SubtitulosTuto;

    public bool Activate = false;

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
            Voices();

            Invoke("subtitulosTuto", 4.5f);

            Activate = false;
            var Collider = GetComponent<Collider>().enabled = false;
        }
    }

    void Voices()
    {
        Subtitulos.SaveSubtitle("Quizas la llave abra el candado", 4f, Voces[0]);

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

    void subtitulosTuto()
    {
        SubtitulosTuto.SaveSubtitle("Pulsa [E] para abrir el inventario", 4f);
        SubtitulosTuto.SaveSubtitle("Equipate la llave para interactuar con el candado", 4f);

        SubtitulosTuto.isOn = true;
        SubtitulosTuto.TextDone = true;
    }
}
