using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Demon_Spawner_Room : MonoBehaviour
{
    public Scr_Cordura Cordura;
    public GameObject Demon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Cordura.GoScream)
        {
            Demon.SetActive(true);
        }


    }
}
