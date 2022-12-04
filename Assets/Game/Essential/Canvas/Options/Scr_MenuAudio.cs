using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Scr_MenuAudio : MonoBehaviour
{
    [Header("Referencias")]
    public Scr_InputSystem Inputs;
    [Space]
    public Scr_OptionsMenu Options;
    public AudioMixer Mixer;

    [Header("Casos de escojer")]
    public int SettingsPos = 0;
    [Space]
    public GameObject SettingsSel;
    [Space]
    public GameObject[] Settings;

    [Header("Prefabs")]
    public Slider Button_Master;
    public Slider Button_Sound;
    public Slider Button_Music;
    public Slider Button_Voice;






    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            if (SettingsPos == 0)  // -- Master -- // 
            {
                SliderMenu();
            }

            if (SettingsPos == 1)  // -- Sounds -- // 
            {
                SliderMenu();
            }

            if (SettingsPos == 2)  // -- Music -- // 
            {
                SliderMenu();
            }

            if (SettingsPos == 3)  // -- Voices -- // 
            {
                SliderMenu();
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









    public void AudioMaster_Change()
    {
        Inputs.Audio_Master = Button_Master.value;            
        PlayerPrefs.SetFloat("Input_Audio_Master", Inputs.Audio_Master);

        //Funcion//
        Mixer.SetFloat("Audio_Master", (Mathf.Log10(Inputs.Audio_Master) * 20));

    }

    public void AudioSound_Change()
    {
        Inputs.Audio_Sound = Button_Sound.value;            
        PlayerPrefs.SetFloat("Input_Audio_Sound", Inputs.Audio_Sound);

        //Funcion//
        Mixer.SetFloat("Audio_Sound", (Mathf.Log10(Inputs.Audio_Sound) * 20));

    }

    public void AudioMusic_Change()
    {
        Inputs.Audio_Music = Button_Music.value;        
        PlayerPrefs.SetFloat("Input_Audio_Music", Inputs.Audio_Music);

        //Funcion//
        Mixer.SetFloat("Audio_Music", (Mathf.Log10(Inputs.Audio_Music) * 20));
    }

    public void AudioVoice_Change()
    {
        Inputs.Audio_Voice = Button_Voice.value;            
        PlayerPrefs.SetFloat("Input_Audio_Voice", Inputs.Audio_Voice);

        //Funcion//
        Mixer.SetFloat("Audio_Voice", (Mathf.Log10(Inputs.Audio_Voice) * 20));
    }



}
