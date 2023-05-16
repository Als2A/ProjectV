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

    public AudioSource Audio;

    public Scr_PuzzlePlomos Plomos;

    public bool IsOn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UsingObject.PrimaryAction == true && Plomos.PuzzleDone)
        {
            Inputs.ActionOne = false;

            Audio.pitch = Random.Range(0.9f, 1.5f);
            Audio.Play();

            if (Object[0].activeSelf == false)
            {
                for (int i = 0; i < Object.Length; i++)
                {
                    Object[i].SetActive(true);
                }
                
                Skin.transform.DOLocalRotate(new Vector3(0, 0, 7), 0.25f).SetEase(Ease.OutSine);
                IsOn = true;
            }
            else
            {
                for (int i = 0; i < Object.Length; i++)
                {
                    Object[i].SetActive(false);
                }               

                Skin.transform.DOLocalRotate(new Vector3(0, 0, -7), 0.25f).SetEase(Ease.OutSine);

                IsOn = false;
            }            
        }
        else if(UsingObject.PrimaryAction == true && !Plomos.PuzzleDone)
        {
            Inputs.ActionOne = false;

            Audio.pitch = Random.Range(0.9f, 1.5f);
            Audio.Play();

            if (!IsOn)
            {
                Skin.transform.DOLocalRotate(new Vector3(0, 0, 7), 0.25f).SetEase(Ease.OutSine);

                IsOn = true;
            }
            else
            {
                Skin.transform.DOLocalRotate(new Vector3(0, 0, -7), 0.25f).SetEase(Ease.OutSine);

                IsOn = false;
            }
        }
    }
}
