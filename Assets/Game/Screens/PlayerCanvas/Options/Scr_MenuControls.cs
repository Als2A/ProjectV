using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_MenuControls : MonoBehaviour
{
    [Header("Referencias")]
    public Scr_InputSystem Inputs;
    [Space]
    public Scr_OptionsMenu Options;

    [Header("Casos de escojer")]
    public int SettingsPos = 0;
    [Space]
    public GameObject SettingsSel;
    [Space]
    public GameObject[] Settings;

    [Header("Prefabs")]
    public Slider Button_Sens;
    public Toggle Button_InvertX;
    public Toggle Button_InvertY;


    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeInHierarchy)
        {
            if (SettingsPos == 0)  // -- Sens -- // 
            {
                SliderMenu();
            }

            if (Inputs.Accept && SettingsPos == 1)  // -- Invert X -- // 
            {
                ToggleSwap();
            }

            if (Inputs.Accept && SettingsPos == 2)  // -- Invert Y -- // 
            {
                ToggleSwap();
            }

            if (Inputs.Accept && SettingsPos == 3)  // -- Back -- // 
            {
                CloseSubSettingsMenu();
            }

            MovementMenu();
        }

    }

















    void MovementMenu()
    {
        if (Inputs.Movement_y > 0.5)
        {
            SettingsPos--;
        }

        if (Inputs.Movement_y < -0.5)
        {
            SettingsPos++;
        }



        SettingsPos = Mathf.Clamp(SettingsPos, 0, Settings.Length - 1);
        ResetInventoryPos();
    }

    void ResetInventoryPos()
    {
        SettingsSel.transform.parent = Settings[SettingsPos].transform;
        SettingsSel.transform.position = Settings[SettingsPos].transform.position;

        Inputs.Movement_x = 0;
        Inputs.Movement_y = 0;
    }








    public void SliderMenu()
    {
        Slider SliderButton = SettingsSel.transform.parent.GetComponentInChildren<Slider>();

        if (Inputs.Movement_x > 0.5)
        {
            SliderButton.value += 1;
        }

        if (Inputs.Movement_x < -0.5)
        {
            SliderButton.value -= 1;
        }

        Inputs.Movement_x = 0;
    }

    public void ToggleSwap()
    {
        Inputs.Accept = false;

        Toggle ButtonToggle = SettingsSel.transform.parent.GetComponentInChildren<Toggle>();

        if (ButtonToggle.isOn) { ButtonToggle.isOn = false; }
        else if (!ButtonToggle.isOn) { ButtonToggle.isOn = true; }
    }

    public void CloseSubSettingsMenu()
    {
        Inputs.Accept = false;

        gameObject.SetActive(false);
        Options.SubMenuActive = false;

        
    }









    public void SensChange()
    {
            Inputs.Sens = Button_Sens.value;

            PlayerPrefs.SetFloat("Input_Sens", Inputs.Sens);
    }

    public void InvertXChange()
    {
        if (Button_InvertX.isOn)
        {
            Inputs.InvertX = -1;
        }
        else if (!Button_InvertX.isOn)
        {
            Inputs.InvertX = 1;
        }

        PlayerPrefs.SetInt("Input_InvertX", Inputs.InvertX);        
    }

    public void InvertYChange()
    {
            if (Button_InvertY.isOn)
            {
            Inputs.InvertY = -1;
            }
            else if (!Button_InvertY.isOn)
            {
            Inputs.InvertY = 1;
            }

            PlayerPrefs.SetInt("Input_InvertY", Inputs.InvertY);
        
    }
}
