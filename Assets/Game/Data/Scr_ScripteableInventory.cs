using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data InventoryItem", menuName = "ScriptableObjects/InventoryItem", order = 1)]
public class Scr_ScripteableInventory : ScriptableObject
{
    public int      id;
    public string   Name;
    public Sprite   Image;

    public string   Descripcion;

    public Object Object_Prefab;
}
