using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ButtonHover_OptionsSubMenu_Audio : MonoBehaviour
{
    Scr_MenuAudio SubMenu_Options;
    public int ButtonPos;

    // Start is called before the first frame update
    void Start()
    {
        SubMenu_Options = transform.parent.GetComponent<Scr_MenuAudio>();
    }


    public void OnHover()
    {
        if (gameObject.activeInHierarchy)
        {
            SubMenu_Options.SettingsSel.transform.parent = gameObject.transform;
            SubMenu_Options.SettingsSel.transform.position = gameObject.transform.position;

            SubMenu_Options.SettingsPos = ButtonPos;
        }
    }
}
