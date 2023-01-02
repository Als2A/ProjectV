using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_BlurUI : MonoBehaviour
{

    public GameObject Blur;
    private Renderer BlurMaterial;

    private float LerpTimer = 0f;
    private float TimeLerp = 0;

    private bool LerpOn = false;

    // Start is called before the first frame update
    void Start()
    {
        BlurMaterial = Blur.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(LerpOn)
        {
            LerpTimer += Time.deltaTime * TimeLerp;

            BlurMaterial.material.SetFloat("_Smoothness", Mathf.Lerp(1, 0.5f, LerpTimer));
        }

        Debug.Log("BLUR =" + BlurMaterial.material.GetFloat("_Smoothness"));
    }

    public void BlurOn(float TimeBlur)
    {
        Blur.SetActive(true);
        BlurMaterial.material.SetFloat("_Smoothness", 0.5f);
              
        /*
        TimeBlur = TimeLerp;
        LerpTimer = 0;
        LerpOn = true;
        */
    }

    public void BlurOff()
    {        
        BlurMaterial.material.SetFloat("_Smoothness", 1);

        Invoke("BlurDesactivate", 0.2f);
    }

    void BlurDesactivate()
    {
        Blur.SetActive(false);
    }
}
