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

    [Header("Player")]
    public GameObject PlayerCam;
    public Scr_Animation_Jumpscare Head;

    public bool jump;
    public float TimeScream;

    Vector3 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = Parent.transform.position;
    }

    private void Update()
    {

        Parent.transform.DOLookAt(PlayerCam.transform.position, 0.2f, AxisConstraint.Y);

        if (TimeScream > 5f && !jump)
        {
            float Distance = Vector3.Distance(Parent.transform.position, PlayerCam.transform.position);
            float DotweenDuration = Distance * 0.05f;

            jump = true;

            Animatorr.SetBool("Jump", true);

            //Parent.transform.DOLookAt(PlayerCam.transform.position, 0.2f, AxisConstraint.Y);            
            Parent.transform.DOMove(PlayerCam.transform.position + (Vector3.down * 0.8f) + (Parent.transform.forward * -1 * 1.5f), DotweenDuration).SetEase(Ease.InSine);
        }

        if(Head.JumpScare_Finish == true)
        {
            Parent.SetActive(false);

            Parent.transform.position = StartPosition;

            jump = false;
            TimeScream = 0;

            Invoke("CompJumpScare", 0.2f);
        }
    }

    void CompJumpScare()
    {
        Head.JumpScare_Finish = false;
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

    public void MoveCam()
    {
        //Invoke("RestartAnimator", 5f);
        PlayerCam.transform.parent.GetComponent<Animator>().SetBool("JumpScare",true);
        //Head.JumpScare_Finish = true;
    }

    void RestartAnimator()
    {
        PlayerCam.transform.parent.GetComponent<Animator>().SetBool("JumpScare", false);
    }
}
