using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PaymonWalk : MonoBehaviour
{

    public float Speed;
    Vector3 StartPosition;
    public Scr_Cordura Cordura;

    public GameObject AngryDemon;

    public bool invokeON = true;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;

        if(invokeON)
        {
            StartPosition = transform.position;
            Invoke("ResetDemon", 3f);

            invokeON = false;
        }
    }

    void ResetDemon()
    {
        invokeON = true;
        Cordura.RestartTimeScream();
        transform.position = StartPosition;

        if (AngryDemon != null && Cordura.Cordura > 500f)
        {
            AngryDemon.SetActive(true);
        }        

        gameObject.SetActive(false);
    }

}
