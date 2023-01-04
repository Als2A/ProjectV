using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Scr_IntroGame : MonoBehaviour
{
    public int Titulos;

    [Header("Logicas")]
    public VideoPlayer videoPlayer;

    [Header("Pantallas")]
    public GameObject Video;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Titulos == 0)
        {
            Video.SetActive(true);

            var ClipIsOver = false;

            if (videoPlayer.time >= videoPlayer.length - 0.5f && !ClipIsOver)
            {
                ClipIsOver = true;
                Invoke("SumaTitulo", 3f);
            }
        }
        else if (Titulos == 1)
        {
            SceneManager.LoadScene("Mapa_00");
        }

        Debug.Log("Time: " + videoPlayer.time);
        Debug.Log("Lenght: " + videoPlayer.length);


    }

    void SumaTitulo()
    {
        Titulos += 1;
    }
}
