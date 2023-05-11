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
            Subtitulos.SaveSubtitle("¿Está todo bien por ahí arriba?", 4f, Voces[0]);
            Subtitulos.SaveSubtitle("Muévete y entra en la casa de una vez!", 4f, Voces[1]);

            Subtitulos.isOn = true;
            Subtitulos.TextDone = true;

            Invoke("subtitulosTuto", 9f);

            EventDo = true;
        }

        


    }

    void subtitulosTuto()
    {
        SubtitulosTuto.SaveSubtitle("Usa [WASD] para caminar y [Mouse] para mirar alrededor", 4f);
        SubtitulosTuto.SaveSubtitle("Pulsa [Shift] para correr y [Ctrl] para agacharte", 4f);

        SubtitulosTuto.isOn = true;
        SubtitulosTuto.TextDone = true;
    }
}
