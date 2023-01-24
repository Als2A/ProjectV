using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerScreamer : MonoBehaviour
{
    [Header("Variables")]

    [Space]

    [Header("Referencias")]
    public Scr_InputSystem Inputs;
    public Camera Cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.SphereCast(Cam.transform.position,0.5f, Cam.transform.forward,out hit)) //codigo guiri Ignora LayerMask
        {
            //Debug.Log(hit.transform.name);

            if(hit.transform.CompareTag("Demon"))
            {
                hit.transform.gameObject.GetComponent<Scr_DemonScreamer>().Active = true;
            }
            
        }

    }

    
}
