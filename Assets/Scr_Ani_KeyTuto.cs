using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Ani_KeyTuto : MonoBehaviour
{
    
    public float Amount;
    public float Speed;

    public float SpeedRotation;

    Rigidbody RB;

    float rotation;

    float Timer;
    float DefaultY;

    // Start is called before the first frame update
    void Start()
    {
        DefaultY = transform.localPosition.y;

        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(RB.isKinematic)
        {
            Timer += Time.deltaTime * Amount;

            transform.localPosition = new Vector3(
            transform.localPosition.x, DefaultY + Mathf.Sin(Timer) * Speed,
            transform.localPosition.z);

            rotation += SpeedRotation * Time.deltaTime;

            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
        
    }
}
