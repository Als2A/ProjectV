using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Demon_Scream_Low : MonoBehaviour
{
    public Collider DemonCollider;
    public Animator Animatorr;

    public Scr_Cordura Cordura;

    public GameObject Parent;

    public GameObject AngryDemon;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    public void DemonHide()
    {
        Cordura.RestartTimeScream();

        Animatorr.SetBool("Hide", true);        
    }

    public void ActivarCollider()
    {
        DemonCollider.enabled = true;
        Invoke("DemonHide", 10f);
    }

    public void DesactivarObject()
    {
        Parent.SetActive(false);
        DemonCollider.enabled = false;
        CancelInvoke("DemonHide");

        if(AngryDemon != null && Cordura.Cordura > 1000f)
        {
            AngryDemon.SetActive(true);
        }
    }
}
