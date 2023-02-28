using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Scr_SliderAudio : MonoBehaviour
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
        
        Text.text = Mathf.Clamp((slider.value), 0f, 10f).ToString();
    }


}
