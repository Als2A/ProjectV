using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_FootSteps : MonoBehaviour
{
    public Scr_HandBobCam HandBobCam;
    public AudioSource Audio;

    public bool isPaso;

    Scr_PlayerMovement Player;

    public AudioClip[] Audios;
    public int FloorType;


    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Scr_PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        RaycastHit Hit;

        Physics.Raycast(new Ray(transform.position, Vector3.down), out Hit);
        FloorType = Hit.collider.transform.GetComponentInParent<Scr_Floor>().FloorType;

        Debug.Log(Hit.collider.transform.GetComponentInParent<Scr_Floor>().FloorType);
        */

        if (Mathf.Sin(HandBobCam.BobTimer) <= -0.8 && isPaso && Player.DirMove != Vector3.zero)
        {
            Audio.clip = Audios[0];

            isPaso = false;
            Audio.pitch = Random.Range(0.5f,1.5f);
            Audio.Play();
            
        }
        else if (Mathf.Sin(HandBobCam.BobTimer) >= 0 && !isPaso)
        {
            isPaso = true;
        }
    }

}
