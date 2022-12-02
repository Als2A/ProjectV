using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ButtonHover_SettingsMenu : MonoBehaviour
{
    Scr_OptionsMenu Menu_Options;
    public int ButtonPos;

    // Start is called before the first frame update
    void Start()
    {
        Menu_Options = transform.parent.parent.parent.parent.GetComponent<Scr_OptionsMenu>();
    }


    public void OnHover()
    {
        if (gameObject.activeInHierarchy)
        {
            Menu_Options.MenuSel.transform.parent = gameObject.transform;
            Menu_Options.MenuSel.transform.position = gameObject.transform.position;

            Menu_Options.MenuPos = ButtonPos;
        }
    }
}
