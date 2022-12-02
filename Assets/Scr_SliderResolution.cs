using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scr_SliderResolution : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TextChange()
    {
        if (slider.value == 5)
        {
            Text.text = "1920 x 1200";
        }
        else if (slider.value == 4)
        {
            Text.text = "1920 x 1080";
        }
        else if (slider.value == 3)
        {
            Text.text = "1680 x 1050";
        }
        else if (slider.value == 2)
        {
            Text.text = "1600 x 900";
        }
        else if (slider.value == 1)
        {
            Text.text = "1280 x 800";
        }
        else if (slider.value == 0)
        {
            Text.text = "1280 x 720";
        }
    }
}
