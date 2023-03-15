using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_BlackFade : MonoBehaviour
{
    CanvasGroup CG;

    public bool FadeOn;
    public bool FadeOff;

    public float Speed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        CG = GetComponent<CanvasGroup>();
        Invoke("CallFadeOff", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (FadeOn) FadingOn();
        if (FadeOff) FadingOff();
    }

    public void FadingOn()
    {
        CG.alpha += Speed * Time.deltaTime;

        CG.alpha = Mathf.Clamp01(CG.alpha);

        if (CG.alpha >= 1) FadeOn = false;
    }

    public void FadingOff()
    {
        CG.alpha -= Speed * Time.deltaTime;

        CG.alpha = Mathf.Clamp01(CG.alpha);

        if (CG.alpha <= 0) FadeOff = false;
    }

    public void CallFadeOn()
    {
        FadeOn = true;
    }

    public void CallFadeOff()
    {
        FadeOff = true;
    }
}
