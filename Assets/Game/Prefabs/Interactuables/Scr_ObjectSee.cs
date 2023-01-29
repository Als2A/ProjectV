using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ObjectSee : MonoBehaviour
{
    public bool isSee;
    public bool isSleep;

    public bool OpenAlpha;

    public float Scale;

    public GameObject PrefabModel;

    public Scr_InputSystem Inputs;

    public Scr_PlayerMovement Player;
    public Scr_InteractiveObject UsingObject;

    public Scr_HandBobCam HandBob;

    public GameObject PlayerCam;

    public Transform DesiredTransform;

    Vector3 ModelStartPosition;
    Vector3 ModelStartScale;
    Quaternion ModelStartRotation;

    Scr_MouseLook MouseLook;

    public Scr_BlurUI Blur;


    [Header("Inspector 3D")]
    public GameObject ViewerSet;
    public GameObject ViewerTexture;
    public GameObject InspectorObject;
    public GameObject InspectorRotatingObject;

    CanvasGroup CgAlpha;

    public GameObject InspectorModel;


    // Start is called before the first frame update
    void Start()
    {
        ModelStartPosition = PrefabModel.transform.position;
        ModelStartScale = PrefabModel.transform.localScale;
        ModelStartRotation = PrefabModel.transform.rotation;

        CgAlpha = ViewerTexture.GetComponent<CanvasGroup>();

        MouseLook = PlayerCam.GetComponent<Scr_MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (UsingObject.PrimaryAction == true && !isSleep)
        {
            UsingObject.PrimaryAction = false;
            isSleep = true;

            DesiredTransform.rotation = PlayerCam.transform.rotation;
            DesiredTransform.position = PlayerCam.transform.position + (PlayerCam.transform.forward * 0.1f);
            DesiredTransform.localScale = Vector3.one * (Scale/5);
            
            MouseLook.CameraLock = true;
            MouseLook.ToLock = true;
            HandBob.isLock = true;

            Player.isLock = true;

            Blur.BlurOn(0.5f);


            Invoke("OpenInspector", 0.2f);            
        }


        if (isSee) // -- Inspector 3D Update --  //
        {
            if (Inputs.OpenInventory || Inputs.Cancel)
            {
                DesiredTransform.transform.position = ModelStartPosition;
                DesiredTransform.transform.localScale = ModelStartScale;
                DesiredTransform.transform.rotation = ModelStartRotation;

                 
                MouseLook.ToLock = false;
                Player.isLock = false;
                HandBob.isLock = false;

                CloseInspector();

                Blur.BlurOff();


                Invoke("SleepOff", 0.5f);
            }
        }

        if(OpenAlpha)
        {
            CgAlpha.alpha += 5f * Time.deltaTime;

            CgAlpha.alpha = Mathf.Clamp01(CgAlpha.alpha);

            if(CgAlpha.alpha >= 1)
            {
                OpenAlpha = false;
                PrefabModel.SetActive(false);
            }
        }

        float lerpTime = 10 * Time.deltaTime;

        PrefabModel.transform.rotation = Quaternion.Lerp(PrefabModel.transform.rotation,DesiredTransform.rotation,lerpTime);
        PrefabModel.transform.position = Vector3.Lerp(PrefabModel.transform.position, DesiredTransform.position, lerpTime);
        PrefabModel.transform.localScale = Vector3.Lerp(PrefabModel.transform.localScale, DesiredTransform.localScale, lerpTime); 

    }

    void SleepOff()
    {
        isSleep = false;
    }

    void OpenInspector()
    {
        if (!isSee)
        {
            Inputs.ActionOne = true;
            Inputs.ActionOne = false;

            isSee = true;
            
            Destroy(InspectorRotatingObject.transform.GetChild(0).gameObject);

            InspectorRotatingObject.transform.localScale = Vector3.one * (Scale);

            InspectorModel = Instantiate(PrefabModel, InspectorObject.transform.position, InspectorObject.transform.rotation, InspectorRotatingObject.transform);
            InspectorModel.transform.localScale = Vector3.one;

            

            CgAlpha.alpha = 0;
            OpenAlpha = true;

            ViewerTexture.SetActive(true);
            ViewerSet.SetActive(true);

            Inputs.Inputs.SwitchCurrentActionMap("Menu");
        }
    }

    void CloseInspector()
    {
        if (isSee)
        {
            Inputs.OpenInventory = false;
            Inputs.Cancel = false;

            isSee = false;
            PrefabModel.SetActive(true);
            ViewerTexture.SetActive(false);
            ViewerSet.SetActive(false);

            Inputs.Inputs.SwitchCurrentActionMap("Player");
        }
    }
}
