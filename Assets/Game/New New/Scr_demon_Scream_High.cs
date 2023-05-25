using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scr_demon_Scream_High : MonoBehaviour
{
    public Collider DemonCollider;
    public Animator Animatorr;

    public Scr_Cordura Cordura;

    public GameObject Skin;
    public GameObject Parent;

    [Header("Player")]
    public GameObject PlayerCam;
    public Scr_Animation_Jumpscare Head;

    public bool jump;
    public float TimeScream;

    Vector3 StartPosition;

    public AudioSource AudioSource;

    public AudioClip[] HighAudios;

    public bool AudioJumpScare;

    public float DistanceJump = 1.5f;
    public float AlturaJump = 0.8f;

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

            High_Audio_JumpScare();

            //Parent.transform.DOLookAt(PlayerCam.transform.position, 0.2f, AxisConstraint.Y);            
            Parent.transform.DOMove(PlayerCam.transform.position + (Vector3.down * AlturaJump) + (Parent.transform.forward * -1 * DistanceJump), DotweenDuration).SetEase(Ease.InSine);
        }

        if(Head.JumpScare_Finish == true)
        {
            Skin.SetActive(false);

            Parent.transform.position = StartPosition;

            jump = false;
            TimeScream = 0;

            Invoke("CompJumpScare", 0.2f);
            Invoke("ParentDesactivate", 7f);
        }
    }

    void CompJumpScare()
    {
        Head.JumpScare_Finish = false;
    }

    public void ParentDesactivate()
    {        
        Parent.SetActive(false);
        Skin.SetActive(true);
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
        Head.transform.GetComponent<Animator>().SetBool("JumpScare",true);
        //Head.JumpScare_Finish = true;
    }

    void High_Audio_JumpScare()
    {
        if (!AudioJumpScare)
        {
            AudioJumpScare = true;

            AudioSource.clip = HighAudios[Random.Range(0, HighAudios.Length)];

            AudioSource.pitch = Random.Range(0.9f, 1.4f);
            AudioSource.Play();

            Invoke("ResetAudioJumpScare", 5f);
        }

    }

    void ResetAudioJumpScare()
    {
        AudioJumpScare = false;
        AudioSource.clip = null;
    }

    void RestartAnimator()
    {
        PlayerCam.transform.parent.GetComponent<Animator>().SetBool("JumpScare", false);
    }
}
