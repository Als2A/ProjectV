using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PuzzlePlomos : MonoBehaviour
{
    public Scr_PlomoSolo[] Plomo;

    public bool PuzzleDone;

    public bool PuzzleDesactivate;

    public GameObject Lights;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Plomo[0].Abertura == 1 && 
           Plomo[1].Abertura == 1 && 
           Plomo[2].Abertura == 1 && 
           Plomo[3].Abertura == 1 && 
           Plomo[4].Abertura == 1 && 
           Plomo[4].Abertura == 1)
        {
            PuzzleDone = true;            
        } 
        else PuzzleDone = false;


        if(PuzzleDesactivate)
        {
            PuzzleDesactivate = false;

            PlomosDesactive();
        }

        if (PuzzleDone)
        { Lights.SetActive(true); }
        else if (!PuzzleDone)
        { Lights.SetActive(false); }
    }

    void PlomosDesactive()
    {
        int PlomosCambiar = Random.Range(3,6);

        for (int i = 0; i < PlomosCambiar; i++)
        {
            Plomo[Random.Range(0, 5)].Abertura = 0;
        }

        
    }
}
