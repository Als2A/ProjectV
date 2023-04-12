using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scr_Cajon : MonoBehaviour
{
    [Header("Variables")]
    public float Distancia;
    //private float smoothSpeed = 0.12f;

    [Header("Estados")]
    [Range(0.0f, 1f)] public float Abertura;

    [Header("Referencias")]
    public Scr_InteractiveObject UsingObject;
    public Scr_InputSystem Input;
    public Scr_MouseLook MouseCam;
    public GameObject FollowPos;

    
    void Update()
    {
        if(UsingObject.SecondaryAction == true)
        {
            if (Abertura < 0.5) Abertura = 1;
            else if (Abertura >= 0.5) Abertura = 0;

            UsingObject.SecondaryAction = false;
        }

        if (Abertura > 1) Abertura = 1;
        if (Abertura < 0) Abertura = 0;

        FollowPos.transform.localPosition = new Vector3(0,0,Abertura*Distancia);

        transform.DOMove(FollowPos.transform.position, 0.5f);
    }    
}
