using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scr_OnOff : MonoBehaviour
{

    [Header("Referencias")]
    public GameObject[] Object;
    [Space]
    public Scr_InteractiveObject UsingObject;    
    public Scr_InputSystem Inputs;

    public GameObject Skin;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UsingObject.PrimaryAction == true)
        {
            if (Object[0].activeSelf == false)
            {
                for (int i = 0; i < Object.Length; i++)
                {
                    Object[i].SetActive(true);
                }
                
                Inputs.ActionOne = false;

                Skin.transform.DOLocalRotate(new Vector3(0, 0, 7), 0.25f).SetEase(Ease.OutSine);
            }
            else
            {
                for (int i = 0; i < Object.Length; i++)
                {
                    Object[i].SetActive(false);
                }

                Inputs.ActionOne = false;

                Skin.transform.DOLocalRotate(new Vector3(0, 0, -7), 0.25f).SetEase(Ease.OutSine);
            }
        }
    }
}
