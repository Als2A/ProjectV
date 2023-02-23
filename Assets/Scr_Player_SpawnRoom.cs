using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_SpawnRoom : MonoBehaviour
{
    public Scr_Cordura Cordura;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            Cordura.SpawnerRoom = other.GetComponent<Scr_Demon_Spawner_Room>();
        }
    }
}
