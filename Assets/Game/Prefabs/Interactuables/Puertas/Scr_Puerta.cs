using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scr_Puerta : MonoBehaviour
{

    [Header("Variables")]
    public float Grados = 110;
    private float smoothSpeed = 0.12f;
    public bool inverted;
    public bool Locked;

    [Header("Estados")]
    [Range(0.0f, 1f)] public float Abertura;

    [Header("Referencias")]
    public Scr_InteractiveObject UsingObject;
    public Scr_MouseLook MouseCam;
    public Scr_InputSystem Input;
    public GameObject FollowPos;

    private void Start()
    {
        
    }


    void Update()
    {
        if (!Locked)
        {
            if (UsingObject.SecondaryAction == true)
            {
                if (Abertura < 0.5) Abertura = 1;
                else if (Abertura >= 0.5) Abertura = 0;


                UsingObject.SecondaryAction = false;
            }
        }



        if (Abertura > 1) Abertura = 1;
        if (Abertura < 0) Abertura = 0;

        FollowPos.transform.localRotation = Quaternion.Euler(0,Abertura * (Locked == true ? Grados = 2f : Grados = 110f) ,0);

        if (Locked && Grados >= 0)
            Invoke("ResetFollowPos", 1f * Time.deltaTime);



        transform.DORotate(FollowPos.transform.rotation.eulerAngles, 0.5f);
    }

    public void ResetFollowPos()
    {
        Abertura = 0;
    }
}
