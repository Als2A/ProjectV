using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scr_Subtitulos : MonoBehaviour
{
    private TextMeshProUGUI TextMesh;

    public AudioSource AudioVoz;

    public bool isOn = false;
    public bool TextOn = false;
    public bool TextDone = false;

    public List<string> Sub_Text = new List<string>();
    public List<float> Sub_Time= new List<float>();

    public List<AudioClip> Sub_Audio = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        TextMesh = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn)
        {
            if(TextDone)
            {
                TextDone = false;

                if(Sub_Text.Count != 0)
                {
                    InsertSubtitle(Sub_Text[0], Sub_Time[0], Sub_Audio[0]);                    
                }                
            }
        }
    }

    public void SaveSubtitle(string Text, float Time, AudioClip Audio)
    {
        Sub_Text.Add(Text);
        Sub_Time.Add(Time);

        Sub_Audio.Add(Audio);
    }

    public void InsertSubtitle(string Text, float Time, AudioClip Audio)
    {
        TextDone = false;

        TextMesh.text = Text;

        AudioVoz.clip = Audio;
        AudioVoz.Play();

        Invoke("CleanSubtitle", Time);
    }

    void CleanSubtitle()
    {
        TextMesh.text = "";

        Invoke("DoneSubtitle", 0.5f);
    }

    void DoneSubtitle()
    {
        TextDone = true;

        if (Sub_Text.Count != 0)
        {
            Sub_Text.RemoveAt(0);
            Sub_Time.RemoveAt(0);
            Sub_Audio.RemoveAt(0);
        }

        if(Sub_Text.Count == 0)
        {
            isOn = false;
            TextDone = false;
        }
    }
}
