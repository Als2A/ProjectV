using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MainMenu : MonoBehaviour
{
    [Header("Referencias")]
    public Scr_InputSystem Inputs;
    [Space]
    public GameObject MenuOptions;
    [Space]



    [Header("Casos de escojer")]
    public int MenuPos = 0;
    [Space]
    public GameObject MenuSel;
    [Space]
    public GameObject[] MenuButtons;







    // Start is called before the first frame update
    void Start()
    {
        Inputs.Inputs.SwitchCurrentActionMap("Menu");
    }

    // Update is called once per frame
    void Update()
    {

        if (!MenuOptions.activeInHierarchy)
        {
            MovementMenu();

            if (Inputs.Accept && MenuPos == 0)  // -- Continue -- // 
            {
                Inputs.Accept = false;

                Debug.Log("funciono");
                //Function
            }

            if (Inputs.Accept && MenuPos == 1)  // -- New Game -- // 
            {
                Inputs.Accept = false;

                Button_NewGame();
            }

            if (Inputs.Accept && MenuPos == 2)  // -- Options -- // 
            {
                Inputs.Accept = false;

                Button_Options();
            }

            if (Inputs.Accept && MenuPos == 3)  // -- Exit -- // 
            {
                Inputs.Accept = false;

                Button_Exit();
            }
        }

    }

















    void MovementMenu()
    {
        if (Inputs.Movement_y > 0.5)
        {
            MenuPos--;
        }

        if (Inputs.Movement_y < -0.5)
        {
            MenuPos++;
        }

        MenuPos = Mathf.Clamp(MenuPos, 0, MenuButtons.Length-1);
        ResetInventoryPos();
    }

    void ResetInventoryPos()
    {
        MenuSel.transform.parent = MenuButtons[MenuPos].transform;
        MenuSel.transform.position = MenuButtons[MenuPos].transform.position;

        Inputs.Movement_x = 0;
        Inputs.Movement_y = 0;
    }












    public void Button_NewGame()
    {
        Destroy(gameObject.transform.parent.gameObject);
        Inputs.Inputs.SwitchCurrentActionMap("Player");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Button_Options()
    {
        MenuOptions.SetActive(true);
    }

    public void Button_Exit()
    {
        Application.Quit();
    }


}
