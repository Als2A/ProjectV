using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CandadoRanuras : MonoBehaviour
{
    public GameObject[] Ranuras;
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
        int Locks = Ranuras.Length;

        for (int i = 0; i < Ranuras.Length; i++)
        {
            if (Ranuras[i].GetComponent<Scr_PuzzleRanuras>().PuzzleDone)
            { Locks -= 1; }
        }

        if (Locks == 0 && !Inputs.ActionOne)
        {
            Locked = false;
            DoorLockA.Locked = false;

            if(DoorLockB != null)
            DoorLockB.Locked = false;
        }
    }
}
