using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerMovement : MonoBehaviour
{

    //[HideInInspector] 
    [Header("Stats")]
    
    public float Speed_Walk;
    public float Speed_Sprint;
    [Space]
    public float StaminaMax;
    [Space]
    public float Gravity;

    [Space]

    [Header("Variables")]

    private float speed;
    private float Stamina;

    private float DirX;
    private float DirZ;
    private Vector3 DirMove;

    private Vector3 Velocity;
    
    private float SprintCoolDownTime;

    [Space]

    [Header("Variables Fijas")]
    private float GroundDistance = 0.2f;
    private float SprintCoolDown = 2f;

    [Space]

    [Header("Estados")]    
    public bool isGrounded;
    public bool isWalking;
    public bool isSprinting;

    [Space]

    [Header("Referencias")]
    public Scr_InputSystem Inputs;
    public LayerMask GroundMask; 
    CharacterController Controller;
    


    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, GroundDistance, GroundMask);

        if(Inputs.Inputs.currentActionMap == Inputs.PlayerMap)
        {
            Movement();
            Sprint();
        }


        ApplyGravity();
    }





















    void Movement()
    {
        //Coge Teclas
        DirX = Inputs.Movement_x;
        DirZ = Inputs.Movement_y;

        //Movimiento Player
        DirMove = transform.right * DirX + transform.forward * DirZ;
        DirMove = Vector3.ClampMagnitude(DirMove, 1);

        Controller.Move(DirMove * speed * Time.deltaTime);

        if (DirMove != Vector3.zero)
        { isWalking = true; }
        else
        { isWalking = false; }
    }

    void Sprint()
    {
        if (isGrounded)
        {
            if (Inputs.Sprint && Stamina > 2 && DirMove != Vector3.zero)
            {
                isSprinting = true;
                SprintCoolDownTime = SprintCoolDown;
            }

            if (isSprinting)
            {
                speed = Speed_Sprint;

                Stamina -= Time.deltaTime;
            }
            else
            {
                if (Stamina <= StaminaMax)
                {
                    if (SprintCoolDownTime <= 0)
                    {
                        Stamina += Time.deltaTime;
                    }
                    else
                        SprintCoolDownTime -= Time.deltaTime;
                }

                speed = Speed_Walk; speed = Speed_Walk;
            }
        }

        if (!Inputs.Sprint || Stamina <= 0 || Inputs.ActionOne)
        {
            isSprinting = false;
        }
    }

    void ApplyGravity()
    {
        if (!isGrounded)
        {
            Velocity.y += Gravity * Time.deltaTime;
            Controller.Move(Velocity * Time.deltaTime);
        }
    }

}
