using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Evt_TutoMovement : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Player;

    public Scr_Subtitulos Subtitulos;

    private Vector3 StartPos;

    public bool isMainMenu;
    public bool isPlayerMove;

    private float EventTimer;
    private float EventTime = 5;

    private bool EventDo;



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
            Subtitulos.SaveSubtitle("¿Está todo bien por ahí arriba?", 4f);
            Subtitulos.SaveSubtitle("Muévete y entra en la casa de una vez!", 4f);

            Subtitulos.isOn = true;
            Subtitulos.TextDone = true;

            EventDo = true;
        }


    }
}
