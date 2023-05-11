using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_IntroScene : MonoBehaviour
{
    public Camera PlayerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Character_Culling_On()
    {
        PlayerCamera.cullingMask |= 1 << LayerMask.NameToLayer("Player");
    }

    public void Character_Culling_Off()
    {
        PlayerCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));
    }
}
