using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Animation_Jumpscare : MonoBehaviour
{
    public bool JumpScare_Finish = false;
    public Animator animatior;

    public void DesactivateJumpScare()
    {
        animatior.SetBool("JumpScare", false);

        JumpScare_Finish = true;
    }
}
