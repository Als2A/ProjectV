using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EquipedPlayer : MonoBehaviour
{

    public Scr_InputSystem Inputs;
    public Scr_EquipedObject Object;
    public Scr_InteractivePlayer InteractivePlayer;

    public GameObject Mira;

    // Update is called once per frame
    void Update()
    {
        if(Object != null &&  Mira.activeInHierarchy == false)
        {
            if (InteractivePlayer.InteractiveObject == null)
            {
                CheckActions();
            }
            else if(InteractivePlayer.InteractiveObject.PrimaryAction == false && InteractivePlayer.InteractiveObject.SecondaryAction == false)
            {
                CheckActions();
            }
        }

    }

    void CheckActions()
    {
        if (Inputs.ActionOne)
        {
            Object.PrimaryAction = true;

            if(Object.PrimaryPulsar)
            {
                Inputs.ActionOne = false;
            }
        }

        if (Inputs.ActionTwo)
        {
            Inputs.ActionTwo = false;
            Object.SecondaryAction = true;
        }

        if (Object.PrimaryAction && !Inputs.ActionOne && !Object.PrimaryPulsar)
        {
            CancelAction();
        }
    }


    void CancelAction()
    {
        Object.PrimaryAction = false;
        Object.SecondaryAction = false;
    }
}
