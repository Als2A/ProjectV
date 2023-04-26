using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Evt_SustoStart : MonoBehaviour
{
    public Scr_Subtitulos Subtitulos;

    public bool Activate = false;

    float Speed = 1;

    bool DemonMove;

    public GameObject Pack;
    //public GameObject Demon;

    public GameObject ImgScreen;

    public Scr_BlackFade BlackFade;

    public AudioSource SustoSound;

    public Scr_PaymonWalk_Angry Paymon;

    public GameObject PlayerCam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Activate)
        {
            Pack.SetActive(true);

            Invoke("Voices", 2f);
            Invoke("DemonMovement", 2f);            

            Activate = false;
            var Collider = GetComponent<Collider>().enabled = false;
        }

        //if(DemonMove)
        //{
        //    Demon.transform.position += (Demon.transform.forward * Speed * Time.deltaTime);
        //}
    }

    void Voices()
    {
        Subtitulos.SaveSubtitle("Joder sube ya veo algo sospechoso", 4f);

        Subtitulos.isOn = true;
        Subtitulos.TextDone = true;
    }

    void DemonMovement()
    {
        DemonMove = true;

        Paymon.isActive = true;

        Paymon.transform.DOScale(new Vector3(25f,33f,25f),4f);

        Invoke("DemonScream",5f);
    }

    void DemonScream()
    {
        Speed = 30;

        Paymon.GetComponent<Animator>().SetBool("JumpScare", true);
        Paymon.transform.DOMove(PlayerCam.transform.position + (Vector3.down * 0.8f) + (Paymon.transform.forward * -1 * 1.5f), 0.5f).SetEase(Ease.InSine);
       

        SustoSound.Play();

        Invoke("TitleScreen",0.5f);
    }
    void TitleScreen()
    {
        ImgScreen.SetActive(true);

        Invoke("GoMenu", 8f);
        Invoke("Fade", 4f);
    }

    void Fade()
    {
        BlackFade.FadeOn = true;
    }

    void GoMenu()
    {
        SceneManager.LoadScene("Mapa_01");
    }







    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Activate = true;
        }
    }
}
