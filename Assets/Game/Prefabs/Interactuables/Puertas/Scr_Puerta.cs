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

    public AudioSource AudioOpen;
    public AudioSource AudioClose;

    public AudioClip[] ClipOpen;
    public AudioClip[] ClipClose;

    private void Start()
    {
        
    }


    void Update()
    {
        if (!Locked)
        {
            if (UsingObject.SecondaryAction == true)
            {
                if (Abertura < 0.5) 
                {
                    Abertura = 1;

                    AudioOpen.clip = ClipOpen[Random.Range(0, ClipOpen.Length)];

                    AudioOpen.pitch = Random.Range(0.9f, 1.8f);
                    AudioOpen.Play();
                }
                else if (Abertura >= 0.5) 
                {
                    Abertura = 0;

                    AudioClose.clip = ClipClose[Random.Range(0, ClipClose.Length)];

                    AudioClose.pitch = Random.Range(0.9f, 1.8f);
                    AudioClose.Play();
                }


                UsingObject.SecondaryAction = false;

                transform.DOLocalRotate(new Vector3(0, Abertura * Grados, 0), 1f).SetEase(Ease.OutSine);
            }
        }

        if (Abertura > 1)
        {
            Abertura = 1;
        }
        if (Abertura < 0) 
        {
            Abertura = 0;
        }

        if (Locked && Grados >= 0)
            Invoke("ResetFollowPos", 1f * Time.deltaTime);
    }

    public void ResetFollowPos()
    {
        Abertura = 0;
        transform.DOLocalRotate(new Vector3(0, Abertura * Grados, 0), 0.5f).SetEase(Ease.OutSine);
    }

}
