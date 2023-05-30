using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ButtonHover_OptionsSubMenu_Controls : MonoBehaviour
{
    Scr_MenuControls SubMenu_Options;
    public int ButtonPos;

    public AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        SubMenu_Options = transform.parent.GetComponent<Scr_MenuControls>();
    }


    public void OnHover()
    {
        if (gameObject.activeInHierarchy)
        {
            Audio.pitch = (Random.Range(0.9f, 1.2f));
            Audio.Play();

            SubMenu_Options.SettingsSel.transform.parent = gameObject.transform;
            SubMenu_Options.SettingsSel.transform.position = gameObject.transform.position;

            SubMenu_Options.SettingsPos = ButtonPos;
        }
    }
}
