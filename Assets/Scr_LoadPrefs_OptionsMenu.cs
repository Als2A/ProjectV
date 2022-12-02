using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_LoadPrefs_OptionsMenu : MonoBehaviour
{
    [Header("Referencias")]
    public Scr_InputSystem Inputs;

    [Header("Control")]
    public Slider SensSlide;
    public Toggle InvertXToggle;
    public Toggle InvertYToggle;

    [Header("Audio")]
    public Slider AudioMaster;
    public Slider AudioSound;
    public Slider AudioMusic;
    public Slider AudioVoice;

    [Header("Graphics")]
    public Slider Brightness;
    public Slider Quality;
    public Slider Resolution;
    public Toggle Fullscreen;

    private void Start()
    {
        LoadPlayerPrefs();

        ChangeControls();
        ChangeAudio();
        ChangeGraphics();



    }


    void LoadPlayerPrefs()
    {
        Inputs.Sens = PlayerPrefs.GetFloat("Input_Sens", 10f);
        Inputs.InvertX = PlayerPrefs.GetInt("Input_InvertX", 1);
        Inputs.InvertY = PlayerPrefs.GetInt("Input_InvertY", 1);

        Inputs.Audio_Master = PlayerPrefs.GetFloat("Input_Audio_Master", 0.5f);
        Inputs.Audio_Sound  = PlayerPrefs.GetFloat("Input_Audio_Sound", 0.5f);
        Inputs.Audio_Music  = PlayerPrefs.GetFloat("Input_Audio_Music", 0.5f);
        Inputs.Audio_Voice  = PlayerPrefs.GetFloat("Input_Audio_Voice", 0.5f);

        Inputs.Brightness = PlayerPrefs.GetFloat("Input_Brightness", 5);
        Inputs.Quality = PlayerPrefs.GetFloat("Input_Quality", 2);
        Inputs.Resolution = PlayerPrefs.GetFloat("Input_Resolution", 4f);
        Inputs.Fullscreen = PlayerPrefs.GetInt("Input_Fullscreen", 1);


    }

    public void ChangeControls()
    {
        SensSlide.value = Inputs.Sens;

        if (Inputs.InvertX == 1)        { InvertXToggle.isOn = false; }
        else if (Inputs.InvertX == -1)  { InvertXToggle.isOn = true;  }

        if (Inputs.InvertY == 1)        { InvertYToggle.isOn = false; }
        else if (Inputs.InvertY == -1)  { InvertYToggle.isOn = true;  }
    }

    public void ChangeAudio()
    {
        AudioMaster.value = Inputs.Audio_Master;
        AudioSound.value = Inputs.Audio_Sound;
        AudioMusic.value = Inputs.Audio_Music;
        AudioVoice.value = Inputs.Audio_Voice;
    }

    public void ChangeGraphics()
    {
        Brightness.value = Inputs.Brightness;
        Quality.value = Inputs.Quality;
        Resolution.value = Inputs.Resolution;

        if (Inputs.Fullscreen == 1)         { Fullscreen.isOn = true;  }
        else if (Inputs.Fullscreen == 0)    { Fullscreen.isOn = false; }
    }


}
