using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_DemonScripted_00 : MonoBehaviour
{
    public float speed;
    public Vector3 StartPos;

    public GameObject Demon;
    public bool isMoving = false;

    private void Start()
    {
        StartPos = Demon.transform.position;
    }

    private void Update()
    {
        if(isMoving)
        {
            Movement();
        }
    }


    void Movement()
    {
        Demon.transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            isMoving = true;

            Invoke("Hide", 4f);
        }

    }

    void Hide()
    {
        isMoving = false;

        Demon.transform.position = StartPos;

        Demon.SetActive(false);
        gameObject.SetActive(false);
    }
}
