using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MachiQuestDescription : QuestDescripcion
{
    [SerializeField] private TextMeshProUGUI questRecompensa;
    public override void ConfQuestUI(Quest quest)
    {
        base.ConfQuestUI(quest);
        
        questRecompensa.text = //$"-{questForLoad.RecompensaOro} oro" +
                               $"-{quest.RecompensaExp} exp" +
                               $"\n-{quest.RecompensaItem.item.Nombre} x{quest.RecompensaItem.Cantidad}";
    }
    public void AceptarQuest()
    {
        if (QuestForComplete == null)
        {
            return;
        }

        QuestManager.Instance.AddQuest(QuestForComplete);
        gameObject.SetActive(false);
    }
}
