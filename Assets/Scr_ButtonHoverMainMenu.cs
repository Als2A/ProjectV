using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ButtonHoverMainMenu : MonoBehaviour
{
    public Scr_MainMenu MainMenu;
    public RectTransform rectTransform;
    public int ButtonPos;
    public Vector3 OriginalPosition;
    public bool isMove;

    public Vector3 FollowPos;
    

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        OriginalPosition = transform.localPosition;
        FollowPos = transform.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount > 1)
        {
            MoveButton();            
        }
        else
        {
            BackButton();
        }


        transform.localPosition = Vector3.Lerp(transform.localPosition, FollowPos, 0.12f);

    }



    void MoveButton()
    {
        if(!isMove)
        {
            FollowPos = OriginalPosition + (Vector3.right * 60f);
            isMove = true;
        }        
    }
    void BackButton()
    {
        if (isMove)
        {
            FollowPos = OriginalPosition;
            isMove = false;
        }
    }

    public void OnHover()
    {
        if (!MainMenu.MenuOptions.activeInHierarchy)
        {
            MainMenu.MenuSel.transform.parent = gameObject.transform;
            MainMenu.MenuSel.transform.position = gameObject.transform.position;

            MainMenu.MenuPos = ButtonPos;
        }
    }
}
