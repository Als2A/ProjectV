using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PuzzleRanuras : MonoBehaviour
{
    public Scr_InteractiveObject UsingObject;
    public Scr_InputSystem Inputs;

    public GameObject HandObject;
    public int RanuraObject;
    GameObject ObjectInHand;

    public bool PuzzleDone = false;

    public Scr_Inventory Inventory;

    public float Distancia;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UsingObject.PrimaryAction == true)
        {
            //Colocar su data en la data del primer hueco vacio.
            Inputs.ActionOne = false;

            if (HandObject.transform.childCount == 1)
            {
                ObjectInHand = HandObject.transform.GetChild(0).gameObject;

                if (ObjectInHand.GetComponent<Scr_ObjetoRanuras>().Ranura == RanuraObject)
                {
                    PuzzleDone = true;

                    ObjectInHand.transform.parent = gameObject.transform;
                    ObjectInHand.transform.localPosition = Vector3.zero + (Vector3.forward * Distancia);
                    ObjectInHand.transform.localRotation = Quaternion.Euler(Vector3.zero);


                    //Borrar Item del Inventario
                    var ButtonData = Inventory.Items[0].GetComponentInChildren<Scr_InventoryButtonData>();

                    ButtonData.Data = ButtonData.DataNull;
                    ButtonData.UpdateSlot();

                }
            }
        }
    }
}
