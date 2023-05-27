using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Evt_TutoMovement : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Player;

    public Scr_Subtitulos Subtitulos;
    public Scr_SubtitulosTuto SubtitulosTuto;

    private Vector3 StartPos;

    public bool isMainMenu;
    public bool isPlayerMove;

    private float EventTimer;
    private float EventTime = 5;

    private bool EventDo;

    public AudioClip[] Voces;



    // Start is called before the first frame update
    void Start()
    {
        StartPos = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenu == null)
        {
            isMainMenu = false;
        }

        if (Player.transform.position != StartPos)
        {
            isPlayerMove = true;
        }

        if (!isMainMenu && !isPlayerMove)
        {
            EventTimer += 1 * Time.deltaTime;
        }

        if (EventTimer >= EventTime && !EventDo)
        {
            Subtitulos.SaveSubtitle("�Est� todo bien por ah� arriba? �Mu�vete y entra en la casa de una vez!", 5f, Voces[0]);
            //Subtitulos.SaveSubtitle("", 4f, Voces[1]);

            Subtitulos.isOn = true;
            Subtitulos.TextDone = true;

            Invoke("subtitulosTuto", 5.5f);

            EventDo = true;
        }

        


    }

    void subtitulosTuto()
    {
        SubtitulosTuto.SaveSubtitle("Usa [WASD] para caminar y [Mouse] para mirar alrededor", 2.5f);
        SubtitulosTuto.SaveSubtitle("Pulsa [Shift] para correr y [Ctrl] para agacharte", 2.5f);

        SubtitulosTuto.isOn = true;
        SubtitulosTuto.TextDone = true;
    }
}
