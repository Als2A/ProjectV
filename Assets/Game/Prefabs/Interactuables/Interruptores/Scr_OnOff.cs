using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_OnOff : MonoBehaviour
{

    [Header("Referencias")]
    public GameObject Object;
    [Space]
    public Scr_InteractiveObject UsingObject;    
    public Scr_InputSystem Inputs;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UsingObject.PrimaryAction == true)
        {           
            if(Object.activeSelf == false)
            {
                Object.SetActive(true);
                Inputs.ActionOne = false;
            }
            else
            {
                Object.SetActive(false);
                Inputs.ActionOne = false;
            }
        }
    }
}
