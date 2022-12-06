using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ButtonHover_Pause : MonoBehaviour
{
    Scr_Pause Menu_Pause;
    public int ButtonPos;

    // Start is called before the first frame update
    void Start()
    {
        Menu_Pause = transform.parent.parent.parent.GetComponent<Scr_Pause>();
    }


    public void OnHover()
    {
        if (gameObject.activeInHierarchy)
        {
            Menu_Pause.PauseSel.transform.parent = gameObject.transform;
            Menu_Pause.PauseSel.transform.position = gameObject.transform.position;

            Menu_Pause.PausePos = ButtonPos;
        }
    }
}
