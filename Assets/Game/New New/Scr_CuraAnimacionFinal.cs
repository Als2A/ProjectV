using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CuraAnimacionFinal : MonoBehaviour
{
    public Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyGravity()
    {
        RB.useGravity = true;

        RB.AddTorque(Vector3.forward * 2f);
    }
}
