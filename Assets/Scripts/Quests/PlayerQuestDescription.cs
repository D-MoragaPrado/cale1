using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class PlayerQuestDescription : QuestDescripcion
{
    [SerializeField] private TextMeshProUGUI tareaObjetivo;
    [SerializeField] private TextMeshProUGUI recompensaOro;
    [SerializeField] private TextMeshProUGUI recompensaExp;

    [Header("Item")]
    [SerializeField] private Image recompensaItemIcono;
    [SerializeField] private TextMeshProUGUI recompensaItemCantidad;

    private void Update()
    {
        if (QuestForComplete.QuestCompletedCheck)
        {
            return;
        }

        tareaObjetivo.text = $"{QuestForComplete.cantActual}/{QuestForComplete.CantObjetivo}";
    }



    public override void ConfQuestUI(Quest quest)
    {
        base.ConfQuestUI(quest);
        recompensaOro.text = quest.RecompensaOro.ToString();
        recompensaExp.text = quest.RecompensaExp.ToString();
        tareaObjetivo.text = $"{quest.cantActual}/{quest.CantObjetivo}";

        recompensaItemIcono.sprite = quest.RecompensaItem.item.Icono;
        recompensaItemCantidad.text = quest.RecompensaItem.Cantidad.ToString();
    }

    private void QuestCompletedResponse(Quest questCompleted)
    {
        if (questCompleted.ID == QuestForComplete.ID)
        {
            tareaObjetivo.text = $"{QuestForComplete.cantActual}/{QuestForComplete.CantObjetivo}";
            gameObject.SetActive(false);
        }
    }
    
    private void OnEnable()
    {
        if (QuestForComplete.QuestCompletedCheck)
        {
            gameObject.SetActive(false);
        }
        
        Quest.EventQuestCompleted += QuestCompletedResponse;
    }

    private void OnDisable()
    {
        Quest.EventQuestCompleted -= QuestCompletedResponse;
    }
     


}
