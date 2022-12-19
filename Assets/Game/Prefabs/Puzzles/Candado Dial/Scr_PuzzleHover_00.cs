using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PuzzleHover_00 : MonoBehaviour
{
    public Scr_CandadoDial Candado;
    public int ButtonPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHover()
    {
        if (Candado.Inputs.ActionOne == false)
        {
            Debug.Log("Change");

            Candado.Arrow.transform.parent = gameObject.transform;
            Candado.Arrow.transform.position = gameObject.transform.position;

            Candado.Arrow.transform.parent = gameObject.transform.parent;

            Candado.DialPos = ButtonPos;
        }
    }

    public void OnClick()
    {
        //Candado.Diales[ButtonPos].GetComponent<Scr_DialSolo>().DialUse = true
    }

}
