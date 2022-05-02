using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private GameObject panelDialogue;
    [SerializeField] private Image npcIcon;
    [SerializeField] private TMPro.TextMeshProUGUI npcNameTMP;
    [SerializeField] private TMPro.TextMeshProUGUI npcConversationTMP;
    public NPCInteraction NPCDisponible { get; set; }

    //private

    private void Update()
    {
        if ( NPCDisponible == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ConfigPanel(NPCDisponible.Dialogue);
        }
    }



    public void OpenClosePanelDialogue(bool state)
    {
        panelDialogue.SetActive(state);
    }

    private void ConfigPanel(NPCDialogue npcDialogue)
    {
        OpenClosePanelDialogue(true);
        npcIcon.sprite = npcDialogue.Icon;
        npcNameTMP.text = $"{npcDialogue.Name}:";
    }


}
