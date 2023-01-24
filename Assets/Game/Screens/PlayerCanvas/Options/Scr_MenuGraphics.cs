using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_MenuGraphics : MonoBehaviour
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
    public Slider Button_Brightness;
    public Slider Button_Quality;
    public Slider Button_Resolution;
    public Toggle Button_Fullscreen;



    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            if (SettingsPos == 0)  // -- Sens -- // 
            {
                SliderMenu();
            }

            if (SettingsPos == 1)  // -- Sens -- // 
            {
                SliderMenu();
            }

            if (SettingsPos == 2)  // -- Sens -- // 
            {
                SliderMenu();
            }

            if (Inputs.Accept && SettingsPos == 3)  // -- Invert X -- // 
            {
                ToggleSwap();
            }

            if (Inputs.Accept && SettingsPos == 4)  // -- Back -- // 
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









    public void Change_Brightness()
    {        
        Inputs.Brightness = Button_Brightness.value;
        PlayerPrefs.SetFloat("Input_Brightness", Inputs.Brightness);
    }

    public void Change_Quality()
    {
        Inputs.Quality = Button_Quality.value;
        PlayerPrefs.SetFloat("Input_Quality", Inputs.Quality);

        //Funcion
        QualitySettings.SetQualityLevel((int)Inputs.Quality);
    }

    public void Change_Resolution()
    {
        Inputs.Resolution = Button_Resolution.value;
        PlayerPrefs.SetFloat("Input_Resolution", Inputs.Resolution);

        //Funcion//
        CancelInvoke("ResolutionScale");
        Invoke("ResolutionScale", 1f);
    }

    public void ResolutionScale()
    {
        if (Inputs.Resolution == 5)
        {
            Screen.SetResolution(1920, 1200, (Inputs.Fullscreen == 1 ? true : false));
        }
        else if (Inputs.Resolution == 4)
        {
            Screen.SetResolution(1920, 1080, (Inputs.Fullscreen == 1 ? true : false));
        }
        else if (Inputs.Resolution == 3)
        {
            Screen.SetResolution(1680, 1050, (Inputs.Fullscreen == 1 ? true : false));
        }
        else if (Inputs.Resolution == 2)
        {
            Screen.SetResolution(1600, 900, (Inputs.Fullscreen == 1 ? true : false));
        }
        else if (Inputs.Resolution == 1)
        {
            Screen.SetResolution(1280, 800, (Inputs.Fullscreen == 1 ? true : false));
        }
        else if (Inputs.Resolution == 0)
        {
            Screen.SetResolution(1280, 720, (Inputs.Fullscreen == 1 ? true : false));
        }
    }

    public void Change_FullScreen()
    {
        if (Button_Fullscreen.isOn)
        {
            Inputs.Fullscreen = 1;
            Screen.fullScreen = true;
        }
        else if (!Button_Fullscreen.isOn)
        {
            Inputs.Fullscreen = 0;
            Screen.fullScreen = false;
        }

        PlayerPrefs.SetInt("Input_Fullscreen", Inputs.Fullscreen);        
    }
}
