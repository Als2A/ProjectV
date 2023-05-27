using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PuzzlePlomos : MonoBehaviour
{
    public Scr_PlomoSolo[] Plomo;

    public bool PuzzleDone;
    public bool RecentDone;

    public bool PuzzleDesactivate;

    public GameObject[] Lights;
    public AudioSource Audio;




    // Start is called before the first frame update
    void Start()
    {
        Invoke("RandomOff", 300f);
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

        if (PuzzleDone && RecentDone)
        {
            RecentDone = false;

            Invoke("RandomOff", Random.Range(250, 500));

            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i].SetActive(true);
            }
            
        }

        else if (!PuzzleDone)
        {
            RecentDone = true;

            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i].SetActive(false);
            }
        }
    }

    void PlomosDesactive()
    {
        Audio.Play();

        int PlomosCambiar = Random.Range(3,6);

        for (int i = 0; i < PlomosCambiar; i++)
        {
            Plomo[Random.Range(0, 5)].Abertura = 0;
        }        
    }

    void RandomOff()
    {
        PlomosDesactive();
    }
}
