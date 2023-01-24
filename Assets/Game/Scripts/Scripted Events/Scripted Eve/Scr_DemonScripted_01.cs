using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_DemonScripted_01 : MonoBehaviour
{
    public GameObject Demon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Demon.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
