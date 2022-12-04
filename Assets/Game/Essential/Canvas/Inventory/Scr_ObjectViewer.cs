using UnityEngine;
using System.Collections;

public class Scr_ObjectViewer : MonoBehaviour
{

    public Transform targetObject;
    public Camera CanvasCam;
    public Scr_InputSystem Inputs;

    private float xDeg;
    private float yDeg;
    private Quaternion fromRotation;
    private Quaternion toRotation;

    public int speed = 10;
    public float lerpSpeed = 0.125f;

    private Vector3 position;
    private float toPosition;
    public float minZ = -7.5f;
    public float maxZ = -2.5f;
    public float Zoom_speed = 1;
    public float Zoom_lerpSpeed = 1;


    private void Start()
    {
        targetObject = gameObject.transform.GetChild(0);
    }


    void Update()
    {

        if (targetObject != null)
        {
            if(Inputs.Inputs.currentControlScheme == "PC")
            {
                if (Inputs.ActionOne)
                {
                    Movimiento();
                }
            }
            else if(Inputs.Inputs.currentControlScheme == "GamePad")
            {
                Movimiento();
            }

            Zoom();

        }
    }

    void Movimiento()
    {
        fromRotation = targetObject.rotation;

        //xDeg -= Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        //yDeg += Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

        Vector3 axis = new Vector3(Inputs.Look_y, -Inputs.Look_x, 0f);
        Quaternion rotationToApply = Quaternion.AngleAxis(axis.magnitude * Time.deltaTime * speed, axis);
        toRotation = rotationToApply * targetObject.rotation;

        //toRotation = Quaternion.Euler(yDeg, xDeg, 0); 
        targetObject.rotation = Quaternion.Lerp(fromRotation, toRotation, lerpSpeed);
    }

    void Zoom()
    {
        position = CanvasCam.transform.localPosition;

        toPosition = position.z += Inputs.Movement_y * -Zoom_speed;

        position.z = Mathf.Lerp(position.z, toPosition, Zoom_lerpSpeed);

        position.z = Mathf.Clamp(position.z, minZ, maxZ);

        CanvasCam.transform.localPosition = position;
    }
}