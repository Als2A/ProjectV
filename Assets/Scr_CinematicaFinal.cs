using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using DG.Tweening;

public class Scr_CinematicaFinal : MonoBehaviour
{
    public GameObject PlayerCamera;
    public Scr_CandadoRanuras Ranuras;
    public PlayableDirector TimeLine;

    public Transform Pos_1;
    public Transform Pos_2;

    public bool AnimStart = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Ranuras.Locked == false)
        {
            if(AnimStart == false)
            {
                AnimStart = true;

                PlayerCamera.transform.parent.parent.parent.DOMove(Ranuras.transform.position + Ranuras.transform.forward * 1f + Vector3.down * 1.6f, 2f);
                //PlayerCamera.transform.DOLookAt(Ranuras.transform.position,2f);

                PlayerCamera.GetComponentInParent<Scr_PlayerMovement>().isLock = true;

                TimeLine.Play();

                Invoke("EnterRoom", 5f);
            }            
        }
    }

    void EnterRoom()
    {
        PlayerCamera.transform.parent.parent.parent.DOMove(Pos_1.position, 2f);
        //PlayerCamera.transform.DOMove(transform.position - transform.forward * 2f, 5f);

        Invoke("Die", 5f);
    }

    void Die()
    {
        PlayerCamera.GetComponentInParent<Scr_MouseLook>().CameraLock = true;
        PlayerCamera.GetComponentInParent<Scr_MouseLook>().ToLock = true;

        //PlayerCamera.transform.DOMove(Pos_2.position, 0.5f);
        PlayerCamera.transform.DORotate(Pos_2.position, 0.5f);
    }
}
