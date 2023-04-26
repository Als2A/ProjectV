using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PaymonWalk : MonoBehaviour
{

    public float Speed;
    Vector3 StartPosition;
    public Scr_Cordura Cordura;

    public GameObject AngryDemon;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        Invoke("ResetDemon", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    void ResetDemon()
    {
        Cordura.RestartTimeScream();

        gameObject.SetActive(false);

        transform.position = StartPosition;

        if (AngryDemon != null && Cordura.Cordura > 500f)
        {
            AngryDemon.SetActive(true);
        }


    }
}
