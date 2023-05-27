using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EQ_Flashlight : MonoBehaviour
{
    public bool LightOn;

    public Scr_EquipedObject Object;
    public GameObject Light;

    public Scr_ScripteableInventory Data;

    public AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        Data = GameObject.Find("Inventory_Logic").GetComponentInChildren<Scr_Inventory>().Items[0].GetComponentInChildren<Scr_InventoryButtonData>().Data;
    }

    // Update is called once per frame
    void Update()
    {
        if (Object.PrimaryAction)
        {
            Object.PrimaryAction = false;

            Audio.pitch = Random.Range(1.9f, 2.2f);
            Audio.Play();

            if (!LightOn)
            {
                Light.SetActive(true);
                LightOn = true;
            }
            else if(LightOn)
            {
                Light.SetActive(false);
                LightOn = false;
            }
        }

        if(LightOn)
        {
            Data.Variant -= 0.10f * Time.deltaTime;
        }

        if(Data.Variant <= 0)
        {
            Light.SetActive(false);
            LightOn = false;
        }

    }

}
