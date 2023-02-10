using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Cordura : MonoBehaviour
{
    public float Cordura = 10;

    public bool TimeSubstract = false;
    public bool GoScream = false;

    public float TimeScream;

    // Start is called before the first frame update
    void Start()
    {
        RestartTimeScream();
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeSubstract)
        { TimeScream -= Time.deltaTime; }
        

        if (TimeScream <= 0)
        {
            GoScream = true;
            TimeSubstract = false;
        }

        Debug.Log("TimeScream: " + TimeScream);
    }

    public void RestartTimeScream()
    {
        TimeScream = Cordura;
        TimeSubstract = true;
        GoScream = false;
    }
}
