using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scr_demon_Scream_High : MonoBehaviour
{
    public Collider DemonCollider;
    public Animator Animatorr;

    public Scr_Cordura Cordura;

    public GameObject Parent;
    GameObject PlayerCam;

    public bool jump;
    public float TimeScream;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerCam = GameObject.Find("PlayerCamera");
    }

    private void Update()
    {
        

        if(TimeScream > 5f && !jump)
        {
            jump = true;
            Parent.transform.LookAt(PlayerCam.transform.position, Vector3.up);

            Animatorr.SetBool("Jump", true);
            
            float Distance = Vector3.Distance(Parent.transform.position, PlayerCam.transform.position);
            Parent.transform.DOMove(PlayerCam.transform.position + (Vector3.down * 0.8f) + (Parent.transform.forward * -1 * 1.5f), Distance * 0.05f).SetEase(Ease.InSine);
        }
    }

    public void DemonHide()
    {
        Cordura.RestartTimeScream();

        Animatorr.SetBool("Hide", true);
    }

    public void ActivarCollider()
    {
        DemonCollider.enabled = true;
        Invoke("DemonHide", 10f);
    }

    public void DesactivarObject()
    {
        Parent.SetActive(false);
        DemonCollider.enabled = false;
        CancelInvoke("DemonHide");
    }
}
