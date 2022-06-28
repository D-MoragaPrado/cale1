using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class Quest : ScriptableObject
{

    public static Action<Quest> EventQuestCompleted;

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
    [HideInInspector] public bool QuestCompletedCheck;

    
    public void AddProgress(int cantidad)
    {
        cantActual += cantidad;
        CheckQuestCompleted();
    }

    private void CheckQuestCompleted()
    {
        if (cantActual >= CantObjetivo)
        {
            cantActual = CantObjetivo;
            QuestCompleted();
        }
    }
    
    private void QuestCompleted()
    {
        if (QuestCompletedCheck)
        {
            return;
        }

        QuestCompletedCheck = true;
        EventQuestCompleted?.Invoke(this);
    }
    
    private void OnEnable()
    {
        QuestCompletedCheck = false;
        cantActual = 0;
    }
    
    
}

[Serializable]
public class QuestRecompensaItem
{
    public InventoryItem item;
    public int Cantidad;
}
