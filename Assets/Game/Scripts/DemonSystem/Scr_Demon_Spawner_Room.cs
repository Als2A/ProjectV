using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Demon_Spawner_Room : MonoBehaviour
{
    public Scr_Cordura Cordura;
    public GameObject[] Demon;

    public bool CorduraActives;

    public bool DemonActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Cordura.GoScream && Cordura.ActivateGoScream && !DemonActive && CorduraActives)
        {
            DemonActive = true;
            CorduraActives = false;
            Cordura.ActivateGoScream = false;

            if (Demon.Length != 0)
                Demon[Random.Range(0, Demon.Length)].SetActive(true);
            else
                Cordura.RestartTimeScream();
        }

        if(!Cordura.GoScream && DemonActive)
        {
            DemonActive = false;
        }
    }
}
