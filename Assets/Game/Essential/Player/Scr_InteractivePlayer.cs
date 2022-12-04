using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_InteractivePlayer : MonoBehaviour
{
    [Header("Variables")]
    public float InteractiveRange;

    [Space]

    [Header("Referencias")]
    public Scr_InputSystem Inputs;
    public Camera Cam;
    public GameObject Mira;
    public Scr_InteractiveObject InteractiveObject;


    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, InteractiveRange)) //codigo guiri Ignora LayerMask
        {
            if (hit.transform.CompareTag("Interactive")) Look(hit); 
                else NoLook();
        }
        else
            NoLook();
    }





// --- Look Voids ---


    void Look(RaycastHit hit)
    {
        Mira.SetActive(true);

        if (Inputs.ActionOne)
        {
            DoAction(hit);
            
        }

        if (Inputs.ActionTwo)
        {
            DoSecondaryAction(hit);            
        }

        if (InteractiveObject != null)
        if (InteractiveObject.PrimaryAction && !Inputs.ActionOne)
        {
            CancelAction();
        }
    }

    void NoLook()
    {
        Mira.SetActive(false);

        if (InteractiveObject != null)
        if (InteractiveObject.PrimaryAction && !Inputs.ActionOne)
        {
            CancelAction();
        }
    }








// --- Action Voids ---


    void DoAction(RaycastHit hit)
    {
        //Inputs.ActionOne = false;

        InteractiveObject = hit.transform.gameObject.GetComponent<Scr_InteractiveObject>();
        InteractiveObject.PrimaryAction = true;
    }

    void DoSecondaryAction(RaycastHit hit)
    {
        Inputs.ActionTwo = false;

        InteractiveObject = hit.transform.gameObject.GetComponent<Scr_InteractiveObject>();
        InteractiveObject.SecondaryAction = true;
    }

    void CancelAction()
    {        
        InteractiveObject.PrimaryAction = false;
        InteractiveObject.SecondaryAction = false;

        InteractiveObject = null;
    }
}
