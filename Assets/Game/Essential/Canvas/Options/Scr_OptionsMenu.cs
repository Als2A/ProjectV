using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_OptionsMenu : MonoBehaviour
{
    [Header("Referencias")]
    public Scr_InputSystem Inputs;
    [Space]
    public GameObject MenuOpciones;
    //public Scr_LoadPrefs_OptionsMenu LoadPrefs;

    [Header("SubMenus")]
    public bool SubMenuActive;

    public GameObject[] SubMenus;




    [Header("Casos de escojer")]
    public int MenuPos = 0;
    [Space]
    public GameObject MenuSel;
    [Space]
    public GameObject[] MenuButtons;

    







    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (MenuOpciones.activeInHierarchy && !SubMenuActive)
        {
            MovementMenu();

            if (Inputs.Accept && MenuPos == 0)  // -- Controls -- // 
            {
                Inputs.Accept = false;

                Button_Controls();
            }

            if (Inputs.Accept && MenuPos == 1)  // -- Audio -- // 
            {
                Inputs.Accept = false;

                Button_Audio();
            }

            if (Inputs.Accept && MenuPos == 2)  // -- Graphics -- // 
            {
                Inputs.Accept = false;

                Button_Graphics();
            }

            if (Inputs.Accept && MenuPos == 3)  // -- Back -- // 
            {
                Inputs.Accept = false;

                Button_Back();
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






    public void Button_Back()
    {
        if (MenuOpciones.activeInHierarchy)
        {
            Close_AllSubMenu();
            MenuOpciones.SetActive(false);

            //MenuPos = 0;
        }
            
    }

    public void Close_AllSubMenu()
    {
        for (int i = 0; i < SubMenus.Length; i++)
        {
            SubMenus[i].SetActive(false);
        }

        SubMenuActive = false;
    }






    public void Button_Controls()
    {
        Close_AllSubMenu();

        if (MenuOpciones.activeInHierarchy)
        {
            SubMenuActive = true;
            SubMenus[0].SetActive(true);

            //LoadPrefs.ChangeControls();
        }

    }

    public void Button_Audio()
    {

        Close_AllSubMenu();

        if (MenuOpciones.activeInHierarchy)
        {
            SubMenuActive = true;
            SubMenus[1].SetActive(true);

            //LoadPrefs.LoadAudio();
        }

    }

    public void Button_Graphics()
    {
        Close_AllSubMenu();


        if (MenuOpciones.activeInHierarchy)
        {
            SubMenuActive = true;
            SubMenus[2].SetActive(true);

            //LoadPrefs.LoadAudio();
        }

    }


}
