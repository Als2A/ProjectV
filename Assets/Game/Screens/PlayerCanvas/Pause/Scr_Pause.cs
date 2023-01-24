using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_Pause : MonoBehaviour
{
    [Header("Referencias")]
    public Scr_InputSystem Inputs;
    public Scr_PlayerMovement Movement;

    [Header("Estados")]
    public bool isPause;


    [Header("Menu de Items")]
    public int PausePos = 0;
    [Space]
    public GameObject PauseMenu;
    public GameObject PauseSel;
    [Space]
    public GameObject[] PauseButtons;


    public GameObject OptionsMenu;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Inputs.Inputs.currentActionMap == Inputs.PlayerMap && !OptionsMenu.activeSelf)
        {
            if (Inputs.Pause)
            {
                if (!PauseMenu.activeSelf)
                {
                    Movement.isWalking = false;
                    Movement.isSprinting = false;

                    Inputs.Pause = false;

                    PauseMenu.SetActive(true);

                    Cursor.lockState = CursorLockMode.None;

                    Inputs.Inputs.SwitchCurrentActionMap("Menu");

                    isPause = true;
                }
            }
        }

        if (Inputs.Inputs.currentActionMap == Inputs.UiMap && isPause && !OptionsMenu.activeSelf)
        {

            MovementMenu();

            if (PausePos == 0 && Inputs.Accept || Inputs.Pause)
            {
                Button_Continue();
            }

            if (PausePos == 1 && Inputs.Accept)
            {
                Button_Options();
            }

            if (PausePos == 2 && Inputs.Accept)
            {
                Button_MainMenu();
            }

        }
    }

    void MovementMenu()
    { 
        if(Inputs.Movement_y > 0.5)
        {
            PausePos--;            
        }

        if (Inputs.Movement_y < -0.5)
        {
            PausePos++;            
        }

        PausePos = Mathf.Clamp(PausePos, 0, PauseButtons.Length-1);
        ResetInventoryPos();
    }

    void ResetInventoryPos()
    {
        PauseSel.transform.parent = PauseButtons[PausePos].transform;
        PauseSel.transform.position = PauseButtons[PausePos].transform.position;

        Inputs.Movement_x = 0;
        Inputs.Movement_y = 0;        
    }






    public void Button_Continue()
    {
        if (PauseMenu.activeSelf)
        {
            Inputs.Pause = false;
            Inputs.Accept = false;

            PauseMenu.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;

            Inputs.Inputs.SwitchCurrentActionMap("Player");

            isPause = false;
        }
    }

    public void Button_Options()
    {
        if (!OptionsMenu.activeSelf)
        {
            Inputs.Accept = false;

            OptionsMenu.SetActive(true);                 
        }
    }

    public void Button_MainMenu()
    {
        SceneManager.LoadScene("Mapa_00");
    }
}
