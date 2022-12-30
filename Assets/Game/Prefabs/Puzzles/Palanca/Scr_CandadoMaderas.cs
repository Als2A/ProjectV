using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CandadoMaderas : MonoBehaviour
{
    public GameObject[] Maderas;
    public bool Locked;

    public Scr_InputSystem Inputs;

    public Scr_Puerta DoorLockA;
    public Scr_Puerta DoorLockB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ComprobarSolucion();
    }

    void ComprobarSolucion()
    {
        int Locks = Maderas.Length;

        for (int i = 0; i < Maderas.Length; i++)
        {
            if (Maderas[i].GetComponent<Rigidbody>().isKinematic == false)
            { Locks -= 1; }
        }

        if (Locks == 0 && !Inputs.ActionOne)
        {
            Locked = false;
            DoorLockA.Locked = false;
            DoorLockB.Locked = false;
        }
    }
}
