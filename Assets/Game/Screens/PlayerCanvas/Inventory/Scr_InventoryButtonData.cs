using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_InventoryButtonData : MonoBehaviour
{
    public Scr_ScripteableInventory OriginalData;
    public Scr_ScripteableInventory Data;

    public Scr_ScripteableInventory DataNull;

    public int ButtonPos;

    Image ObjectImage;

    public string Descripcion;

    // Start is called before the first frame update
    void Awake()
    {
        Data = new Scr_ScripteableInventory();
        ObjectImage = GetComponent<Image>();

        if (OriginalData != null)
        {
            GetData();

            UpdateSlot();            
        }
        else
            Data = DataNull;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GetData()
    {
        Data.id = OriginalData.id;
        Data.Name = OriginalData.Name;
        Data.Descripcion = OriginalData.Descripcion;
        Data.Image = OriginalData.Image;

        Data.Variant = OriginalData.Variant;

        Data.CombinePrimary = OriginalData.CombinePrimary;
        Data.CombineDestroy = OriginalData.CombineDestroy;
        Data.CombineObjectID  = OriginalData.CombineObjectID;
        Data.CombineResult  = OriginalData.CombineResult;

        Data.InspectorScale = OriginalData.InspectorScale;

        Data.Object_Prefab = OriginalData.Object_Prefab;

        Data.name = "DataPlayer_" + Data.Name;
    }

    public void UpdateSlot()
    {
        ObjectImage.sprite = Data.Image;
    }
}
