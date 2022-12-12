using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CandadoDial : MonoBehaviour
{

    public bool Locked;
    public bool isInterface;

    public Scr_InteractiveObject UsingObject;
    public Scr_InputSystem Inputs;

    public GameObject PlayerHead;
    public GameObject PlayerCamera;


    public Transform DesiredTransform;


    public bool Lerp;


    Rigidbody Rb;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Abrir Interfaz
        if (UsingObject.PrimaryAction == true && Inputs.Inputs.currentActionMap == Inputs.PlayerMap)
        {
            Inputs.ActionOne = false;
            ActiveInterface();
        }

        //Interfaz Abierta
        if (isInterface && Inputs.Inputs.currentActionMap == Inputs.UiMap)
        {
            //Cerrar Interfaz
            if (Inputs.OpenInventory || Inputs.Cancel)
            {
                DesactiveInterface();
            }


        }
    }

    void ActiveInterface()
    {
        Inputs.Inputs.SwitchCurrentActionMap("Menu");

        PlayerHead.GetComponentInChildren<Scr_MouseLook>().CameraLock = true;
        PlayerHead.GetComponentInChildren<Scr_MouseLook>().ToLock = true;

        PlayerHead.GetComponentInChildren<Scr_HandBobCam>().isLock = true;

        Cursor.lockState = CursorLockMode.None;

        isInterface = true;






        PlayerHead.transform.rotation = gameObject.transform.rotation;
        PlayerHead.transform.position = gameObject.transform.position - (gameObject.transform.forward * 0.5f);

        PlayerCamera.transform.rotation = gameObject.transform.rotation;
    }

    void DesactiveInterface()
    {
        Inputs.OpenInventory = false;
        Inputs.Cancel = false;

        Inputs.Inputs.SwitchCurrentActionMap("Player");

        PlayerHead.GetComponentInChildren<Scr_MouseLook>().ToLock = false;

        PlayerHead.GetComponentInChildren<Scr_HandBobCam>().isLock = false;

        Cursor.lockState = CursorLockMode.Locked;

        isInterface = false;





        PlayerHead.transform.localRotation = PlayerHead.transform.parent.localRotation;
        PlayerHead.transform.localPosition = PlayerHead.transform.parent.localPosition + Vector3.up * 1.6f;

        PlayerCamera.transform.localPosition = Vector3.zero;
        PlayerCamera.transform.localRotation = PlayerHead.transform.localRotation;
    }

}
