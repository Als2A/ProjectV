using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_DialSolo : MonoBehaviour
{
    public Scr_CandadoDial Candado;
    public Scr_InputSystem Inputs;

    [Range(0, 9)] public int Number;
    [Range(0, 1)] public float Vuelta;


    public bool isUsing;
    public bool isPos;

    public bool isLerp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Candado.Diales[Candado.DialPos] == gameObject)
        {
            isPos = true;
        }
        else
        {
            isPos = false;
        }

        if (isPos && Inputs.ActionOne)
        {
            isUsing = true;
            isLerp = false;
        }
        else
        {
            isUsing = false;
        }



        if (isPos && isUsing)
        {
            float mouseX = Inputs.Look_x * (Inputs.Sens / 100) * Time.deltaTime;

            Vuelta += mouseX;
        }

        transform.localRotation = Quaternion.Euler(0, Vuelta * 360, 0);

        GradosNumeros();


        if (!isUsing && !isLerp)
        {
            isLerp = true;
            Vuelta = ((float)Number) / 10;
        }

        if(isLerp)
        {

        }
    }

    void GradosNumeros()
    {
        if (Vuelta >= 1) Vuelta -= 1;
        if (Vuelta < 0) Vuelta += 1;

             if (Vuelta < 0.1f)    Number = 0;
        else if (Vuelta < 0.2f)    Number = 1;
        else if (Vuelta < 0.3f)    Number = 2;
        else if (Vuelta < 0.4f)    Number = 3;
        else if (Vuelta < 0.5f)    Number = 4;
        else if (Vuelta < 0.6f)    Number = 5;
        else if (Vuelta < 0.7f)    Number = 6;
        else if (Vuelta < 0.8f)    Number = 7;
        else if (Vuelta < 0.9f)    Number = 8;
        else if (Vuelta < 1f)      Number = 9;        
    }





















    void GradoNumeros()
    {
        int Grados;

        Grados = ((int)(transform.localRotation.eulerAngles.y));

        if (Grados <= 0 && Grados >= 35) { Number = 0; }
        if (Grados <= 36 && Grados >= 71) { Number = 1; }
        if (Grados <= 72 && Grados >= 107) { Number = 2; }
        if (Grados <= 108 && Grados >= 143) { Number = 3; }
        if (Grados <= 144 && Grados >= 179) Number = 4;
        if (Grados <= 180 && Grados >= 215) Number = 5;
        if (Grados <= 216 && Grados >= 251) Number = 6;
        if (Grados <= 252 && Grados >= 287) Number = 7;
        if (Grados <= 288 && Grados >= 323) Number = 8;
        if (Grados <= 324 && Grados >= 360) Number = 9;




        Debug.Log(gameObject.name + ":  " + Grados);
    }
}
