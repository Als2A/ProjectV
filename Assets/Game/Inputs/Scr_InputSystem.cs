using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_InputSystem : MonoBehaviour
{
    [Header("References")]
    public PlayerInput Inputs;

    public InputActionMap PlayerMap;
    public InputActionMap UiMap;



    [Header("Inputs")]
    public float Movement_x;
    public float Movement_y;
    public Vector2 Movement;

    public bool Sprint;
    public float ValueSprint;

    public float Look_x;
    public float Look_y;

    public bool ActionOne;
    public bool ActionTwo;

    public bool OpenInventory;
    public bool Pause;

    public bool Accept;
    public bool Cancel;

     
    [Header("Settings")]
    public float Sens;
    public int InvertX;
    public int InvertY;

    public float Audio_Master;
    public float Audio_Sound;
    public float Audio_Music;
    public float Audio_Voice;

    public float Brightness;
    public float Quality;
    public float Resolution;
    public int Fullscreen;



    // Start is called before the first frame update
    void Start()
    {
        PlayerMap = Inputs.actions.FindActionMap("Player");
        UiMap = Inputs.actions.FindActionMap("Menu");
    }

    private void Update()
    {
        
    }

    // -- Buttons --

    public void OnActionOne(InputValue value)
    {
        if (value.Get<float>() > 0.5)
        {
            ActionOne = true;
        }
        else if (value.Get<float>() < 0.5)
        {
            ActionOne = false;
        }
    }

    public void OnActionTwo(InputValue value)
    {
        if (value.Get<float>() > 0.5)
        {
            ActionTwo = true;
        }
        else if (value.Get<float>() < 0.5)
        {
            ActionTwo = false;
        }
    }

    void OnSprint(InputValue value)
    {
        if (value.Get<float>() > 0.5)
        {
            Sprint = true;
        }
        else if (value.Get<float>() < 0.5)
        {
            Sprint = false;
        }
    }

    public void OnOpenInventory(InputValue value)
    {
        if (value.Get<float>() > 0.5)
        {
            OpenInventory = true;
        }
        else if (value.Get<float>() < 0.5)
        {
            OpenInventory = false;
        }
    }

    public void OnPause(InputValue value)
    {
        if (value.Get<float>() > 0.5)
        {
            Pause = true;
        }
        else if (value.Get<float>() < 0.5)
        {
            Pause = false;
        }
    }

    public void OnAccept(InputValue value)
    {
        if (value.Get<float>() > 0.5)
        {
            Accept = true;
        }
        else if (value.Get<float>() < 0.5)
        {
            Accept = false;
        }
    }

    public void OnCancel(InputValue value)
    {
        if (value.Get<float>() > 0.5)
        {
            Cancel = true;
        }
        else if (value.Get<float>() < 0.5)
        {
            Cancel = false;
        }
    }


    // -- Values --

    public void OnMovement(InputValue value)
    {
        Movement = value.Get<Vector2>();
    }

    public void OnMovement_X(InputValue value)
    {
        Movement_x = value.Get<float>();
    }

    public void OnMovement_Y(InputValue value)
    {
        Movement_y = value.Get<float>();
    }

    public void OnLook_X(InputValue value)
    {
        Look_x = value.Get<float>();
    }

    public void OnLook_Y(InputValue value)
    {
        Look_y = value.Get<float>();
    }
}
