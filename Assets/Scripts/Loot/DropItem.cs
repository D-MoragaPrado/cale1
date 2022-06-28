using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DropItem 
{
    [Header("Info")]
    public string Name;
    public InventoryItem Item;
    public int Cant;

    [Header("Drop")]
    [Range(0, 100)] public float PorcentajeDrop;

    public bool ItemRecogido { get; set; }
}
