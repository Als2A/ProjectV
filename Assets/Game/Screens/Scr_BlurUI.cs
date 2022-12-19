using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_BlurUI : MonoBehaviour
{

    public GameObject Blur;
    private Renderer BlurMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlurOn()
    {
        Blur.SetActive(true);
        BlurMaterial = Blur.GetComponent<Renderer>();
        BlurMaterial.material.SetFloat("_Smoothness", 0.5f);
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
