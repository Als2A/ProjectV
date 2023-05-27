using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Cordura : MonoBehaviour
{
    public float Cordura = 10;

    public bool TimeSubstract = false;
    public bool GoScream = false;
    public bool ActivateGoScream = false;

    public bool isDemonActive = false;

    public float TimeScream;
    //public float TimeToJumpscream = 10;

    public Scr_Demon_Spawner_Room SpawnerRoom;

    // Start is called before the first frame update
    void Start()
    {
        RestartTimeScream();
    }

    // Update is called once per frame
    void Update()
    {
        Cordura += Time.deltaTime;

        if(TimeSubstract)
        { TimeScream -= Time.deltaTime; }
        

        if (TimeScream <= 0)
        {
            GoScream = true;
            TimeSubstract = false;
        }

        if (TimeScream <= 0 && !isDemonActive)
        {
            ActivateGoScream = true;
        }

        if (GoScream && ActivateGoScream && SpawnerRoom != null)
        {            
            SpawnerRoom.CorduraActives = true;
            isDemonActive = true;
        }

        Debug.Log("TimeScream: " + TimeScream);
    }

    public void RestartTimeScream()
    {
        float TimeToJumpscream = Random.Range(30, 100);
        
        TimeSubstract = true;
        GoScream = false;

        isDemonActive = false;

        TimeScream = TimeToJumpscream;
    }
}
