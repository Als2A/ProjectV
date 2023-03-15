using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CandadoDial : MonoBehaviour
{

    public bool Locked;
    public Scr_Puerta DoorLock;

    public bool isInterface;

    public Scr_InteractiveObject UsingObject;
    public Scr_InputSystem Inputs;

    public GameObject PlayerHead;
    public GameObject PlayerCamera;
    public GameObject HandObject;
    private Scr_InteractivePlayer Interactive;

    public Transform DesiredTransform;
    private Vector3 SavePosition;
    private Quaternion SaveRotation;

    public GameObject[] Diales;
    public GameObject Arrow;
    public GameObject TheLight;
    public int DialPos;




    public bool Lerp;


    Rigidbody Rb;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Interactive = PlayerHead.transform.parent.GetComponent<Scr_InteractivePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Abrir Interfaz
        if (UsingObject.PrimaryAction == true && Inputs.Inputs.currentActionMap == Inputs.PlayerMap)
        {
            Inputs.ActionOne = false;
            UsingObject.PrimaryAction = false;

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

        if(Locked == true) ComprobarSolucion();
        
    }

    void ActiveInterface()
    {
        Inputs.Inputs.SwitchCurrentActionMap("Menu");

        PlayerHead.GetComponentInChildren<Scr_MouseLook>().CameraLock = true;
        PlayerHead.GetComponentInChildren<Scr_MouseLook>().ToLock = true;

        PlayerHead.GetComponentInChildren<Scr_HandBobCam>().isLock = true;
        PlayerHead.GetComponentInChildren<Scr_HandBobCam>().BobTimer = 0;

        Cursor.lockState = CursorLockMode.None;

        isInterface = true;

        Arrow.SetActive(true);
        TheLight.SetActive(true);

        UsingObject.gameObject.SetActive(false);

        HandObject.SetActive(false);

        Interactive.STOP = true;

        SavePosition = PlayerHead.transform.position;
        SaveRotation = PlayerHead.transform.rotation;

        PlayerHead.transform.rotation = DesiredTransform.rotation;
        PlayerHead.transform.position = DesiredTransform.position;

        PlayerCamera.transform.rotation = DesiredTransform.rotation;
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

        Arrow.SetActive(false);
        TheLight.SetActive(false);

        HandObject.SetActive(true);

        UsingObject.gameObject.SetActive(true);

        Interactive.STOP = false;


        PlayerHead.transform.rotation = SaveRotation;
        PlayerHead.transform.position = SavePosition;

        //PlayerCamera.transform.localPosition = Vector3.zero;
        //PlayerCamera.transform.localRotation = PlayerHead.transform.localRotation;
    }

    void ComprobarSolucion()
    {
        int Locks = Diales.Length;

        for (int i = 0; i < Diales.Length; i++)
        {
            if (Diales[i].GetComponent<Scr_DialSolo>().Number == Diales[i].GetComponent<Scr_DialSolo>().GoodNumber)
            { Locks -= 1; }
        }

        if(Locks == 0 && !Inputs.ActionOne)
        {
            Locked = false;
            DoorLock.Locked = false;

            DesactiveInterface();

            Rb.isKinematic = false;
        }
    }

}
