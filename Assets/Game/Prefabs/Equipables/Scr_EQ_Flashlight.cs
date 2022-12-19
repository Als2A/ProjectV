using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EQ_Flashlight : MonoBehaviour
{
    public bool LightOn;

    public Scr_EquipedObject Object;
    public GameObject Light;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Object.PrimaryAction)
        {
            Object.PrimaryAction = false;

            if(!LightOn)
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
    }

}
