using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_BlackFade : MonoBehaviour
{
    CanvasGroup CG;

    public bool FadeOn;
    public bool FadeOff;

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

    void FadingOn()
    {
        CG.alpha += 0.4f * Time.deltaTime;

        CG.alpha = Mathf.Clamp01(CG.alpha);

        if (CG.alpha >= 1) FadeOn = false;
    }

    void FadingOff()
    {
        CG.alpha -= 0.4f * Time.deltaTime;

        CG.alpha = Mathf.Clamp01(CG.alpha);

        if (CG.alpha <= 0) FadeOff = false;
    }

    void CallFadeOff()
    {
        FadeOff = true;
    }
}
