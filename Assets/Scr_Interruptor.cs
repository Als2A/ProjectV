using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Interruptor : MonoBehaviour
{
    public float Grados;
    [Range(0.0f, 1f)] public float Abertura;

    public GameObject FollowPos;

    public Scr_InteractiveObject UsingObject;

    public bool isSleep;

    void Update()
    {
        if (UsingObject.PrimaryAction == true && !isSleep)
        {


            if (Abertura < 0.5) Abertura = 1;
            else if (Abertura >= 0.5) Abertura = 0;

            UsingObject.PrimaryAction = false;
            isSleep = true;

            Invoke("SleepOff", 0.5f);
        }

        FollowPos.transform.localRotation = Quaternion.Euler(0, Abertura * Grados -8f, 0);

        transform.localRotation = Quaternion.Lerp(transform.localRotation, FollowPos.transform.localRotation, 0.12f);

        //transform.rotation = Quaternion.Euler(Abertura * Grados, 0, 0);
    }

    void SleepOff()
    {
        isSleep = false;
    }
}
