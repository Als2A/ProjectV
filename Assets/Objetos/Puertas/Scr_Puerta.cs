using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Puerta : MonoBehaviour
{

    [Header("Variables")]
    public float Distancia;
    private float smoothSpeed = 0.12f;
    public bool inverted;

    [Header("Estados")]
    [Range(0.0f, 1f)] public float Abertura;

    [Header("Referencias")]
    public Scr_InteractiveObject UsingObject;
    public Scr_MouseLook MouseCam;
    public Scr_InputSystem Input;
    public GameObject FollowPos;   

    
    void Update()
    {
        if (UsingObject.PrimaryAction == true)
        {
            MouseCam.CameraLock = true;

            float mouseY = Input.Look_y * (Input.Sens / 100) * Time.deltaTime;

            if (!inverted)
            {                
                Abertura -= mouseY;
            }
            else
            {
                Abertura += mouseY;
            }
            //float mouseX = Input.GetAxis("Mouse X") * MouseCam.mouseSens * Time.deltaTime;

        }

        if (UsingObject.SecondaryAction == true)
        {
            if (Abertura < 0.5) Abertura = 1;
            else if (Abertura >= 0.5) Abertura = 0;


            UsingObject.SecondaryAction = false;
        }


        if (Abertura > 1) Abertura = 1;
        if (Abertura < 0) Abertura = 0;

        FollowPos.transform.localRotation = Quaternion.Euler(0,Abertura*110,0); 

        transform.rotation = Quaternion.Lerp(transform.rotation,FollowPos.transform.rotation,smoothSpeed);
    }
}
