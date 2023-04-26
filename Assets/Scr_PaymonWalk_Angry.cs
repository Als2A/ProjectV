using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PaymonWalk_Angry : MonoBehaviour
{

    public bool isActive = false;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        { transform.position += transform.forward * Speed * Time.deltaTime; }

    }
}
