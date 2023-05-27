using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evt_TutoPistol : MonoBehaviour
{
    public Scr_Subtitulos Subtitulos;

    public Scr_Inventory Inventory;

    public Scr_Puerta Puerta;

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
            Activate = false;

            Part_00();

            Invoke("Part_01", 1f);
        }
    }

    void Part_00()
    {
        Puerta.AudioPuertaClose();  
        Puerta.Abertura = 0;

        Invoke("PuertaClose", 0.5f);

    }

    void PuertaClose()
    {
        Puerta.Locked = true;
    }

    void Part_01()
    {
        Voices();

        //Invoke("EquipGun", 4f);        
    }

    void Voices()
    {
        Subtitulos.SaveSubtitle("Esto no me gusta nada", 4f, Voces[0]);
        Subtitulos.SaveSubtitle("Tío solamente nos llaman por unos gritos, calma la familia, y si necesitas ayuda avisame por el walkie.", 4f, Voces[1]);
        //Subtitulos.SaveSubtitle("", 4f, Voces[1]);

        Subtitulos.isOn = true;
        Subtitulos.TextDone = true;
    }

    //void EquipGun()
    //{
    //    for (int i = 0; i < Inventory.Items.Length; i++)
    //    {
    //        var Data = Inventory.Items[i].GetComponentInChildren<Scr_InventoryButtonData>();

    //        if(Data.Data.id == 100)
    //        { 
    //            Inventory.ItemsPos = i;
    //            break;
    //        }
    //    }

    //    Inventory.UsesEquip();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            var Collider = GetComponent<Collider>().enabled = false;

            Activate = true;            
        }
    }
}
