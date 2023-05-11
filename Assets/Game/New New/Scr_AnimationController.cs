using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_AnimationController : MonoBehaviour
{
    public Scr_PlayerMovement Player;
    public Animator Anima;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.isWalking)
        {
            Anima.SetBool("Walking", true);
        }
        else
        {
            Anima.SetBool("Walking", false);
        }

        if (Player.isSprinting)
        {
            Anima.SetBool("Running", true);
        }
        else
        {
            Anima.SetBool("Running", false);
        }

        if (Player.isCrouch)
        {
            Anima.SetBool("Crouch", true);
        }
        else
        {
            Anima.SetBool("Crouch", false);
        }
    }
}
