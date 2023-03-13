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

    public bool jump;
    public float TimeScream;

    // Start is called before the first frame update
    void Awake()
    {

    }

    private void Update()
    {
        if(TimeScream > 5f && !jump)
        {
            jump = true;


            Animatorr.SetBool("Jump", true);
            GameObject PlayerCam = GameObject.Find("PlayerCamera");
            float Distance = Vector3.Distance(Parent.transform.position, PlayerCam.transform.position);
            Parent.transform.DOMove(PlayerCam.transform.position + (Vector3.down*1f) + (Vector3.left*1.7f), Distance * 0.05f).SetEase(Ease.InSine);
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
