using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    [Header("Info")]

    public string Nombre;
    public string ID;
    public int CantObjetivo;

    [Header("Info")]
    [TextArea] public string Descripcion;

    [Header("Recompensa")]
    public int RecompensaOro;
    public int RecompensaExp;
    public QuestRecompensaItem RecompensaItem;

    [HideInInspector] public int cantActual;
    [HideInInspector] public bool QuestCompletado;


    

}

[SerializeField]
public class QuestRecompensaItem
{
    public InventoryItem item;
    public int Cantidad;
}
