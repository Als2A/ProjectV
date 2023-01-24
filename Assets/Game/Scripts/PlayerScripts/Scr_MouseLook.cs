using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MouseLook : MonoBehaviour
{
    [Header("Variables")]
    //public float mouseSens = 100f;

    private float xRotation = 0f;
    private float zRotation = 0f;

    [Header("Estados")]
    public bool CameraLock;
    public bool ToLock;

    [Header("Referencias")]
    public Scr_InputSystem Inputs;
    private Transform playerBody;
    public GameObject Menu;




    // Start is called before the first frame update
    void Start()
    {
        playerBody = transform.parent.parent.GetComponent<Transform>();

        if (Inputs.Inputs.currentActionMap == Inputs.PlayerMap)
        { Cursor.lockState = CursorLockMode.Locked; }
    }

    // Update is called once per frame
    void Update()
    {
        if (Inputs.Inputs.currentActionMap == Inputs.PlayerMap)
        {
            if (!CameraLock)
            {
                float mouseX = (Inputs.Look_x * Inputs.InvertX) * Inputs.Sens * Time.deltaTime;
                float mouseY = (Inputs.Look_y * Inputs.InvertY) * Inputs.Sens * Time.deltaTime;

                //Movimiento Player Horizontal
                playerBody.Rotate(Vector3.up * mouseX);

                //Movimiento Vertical
                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);

                //Movimiento en Z
                zRotation -= mouseX * 0.03f;
                zRotation = Mathf.Clamp(zRotation, -7f, 7f);
                if(Inputs.Look_x == 0) 
                    zRotation = Mathf.Lerp(zRotation, 0, 0.1f);

                //Movimiento Camara Final
                transform.localRotation = Quaternion.Euler(xRotation, 0f, zRotation);

            }

            if (CameraLock && !Inputs.ActionOne && !Menu.activeSelf && !ToLock)
            {
                CameraLock = false;
            }
        }
           
    }
}
