using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_DemonIA_00 : MonoBehaviour
{

    public Scr_DemonScreamer Screamer;
    public float speed;

    public bool isMoving = false;
    public GameObject ImgScreen;
    public GameObject Face;
    public Camera Cam;

    public Transform Move;

    // Start is called before the first frame update
    void Start()
    {
        Move = Face.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Screamer.Active)
        {
            Screamer.Active = false;

            isMoving = true;
            Invoke("Screen", 0.5f);
            
        }

        if (isMoving)
        {
            Movement();
            LookAtDemon();
        }
    }

    void Movement()
    {
        
        transform.LookAt(Cam.transform.parent);

        //transform.rotation = Quaternion.Euler(0f, Move.rotation.y, 0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void LookAtDemon()
    {
        Cam.transform.LookAt(Face.transform);
    }

    void Screen()
    {
        ImgScreen.SetActive(true);

        Invoke("GoMenu", 3f);
    }

    void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
