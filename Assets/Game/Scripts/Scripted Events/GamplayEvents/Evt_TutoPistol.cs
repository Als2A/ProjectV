using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evt_TutoPistol : MonoBehaviour
{
    public Scr_Subtitulos Subtitulos;

    public Scr_Inventory Inventory;

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
            Voices();

            Invoke("EquipGun", 4f);

            Activate = false;
            var Collider = GetComponent<Collider>().enabled = false;
        }
    }

    void Voices()
    {
        Subtitulos.SaveSubtitle("Tio esto no me gusta nada", 4f);

        Subtitulos.isOn = true;
        Subtitulos.TextDone = true;
    }

    void EquipGun()
    {
        for (int i = 0; i < Inventory.Items.Length; i++)
        {
            var Data = Inventory.Items[i].GetComponentInChildren<Scr_InventoryButtonData>();

            if(Data.Data.id == 100)
            { 
                Inventory.ItemsPos = i;
                break;
            }
        }

        Inventory.UsesEquip();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Activate = true;
        }
    }
}
