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

    private Queue<string> dialoguesSequence;
    private bool dialogueAnimated;
    private bool despedidaDisplayed;
    private bool saludoDisplayed;


    private void Start()
    {
        dialoguesSequence = new Queue<string>();
        saludoDisplayed = false;
    }
    private void Update()
    {
        if ( NPCDisponible == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!saludoDisplayed)
            {
                ConfigPanel(NPCDisponible.Dialogue);
                saludoDisplayed = true;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (despedidaDisplayed)
            {
                OpenClosePanelDialogue(false);
                despedidaDisplayed = false;
                saludoDisplayed = false;
                return;
            }
            if (NPCDisponible.Dialogue.contExtraInteraction)
            {
                UIManager.Instance.OpenPanelInteraction(NPCDisponible.Dialogue.InteractionExtra);
                OpenClosePanelDialogue(false);
                saludoDisplayed = false;
                despedidaDisplayed = false;
                return;
            }



            if (dialogueAnimated)
            {
                ContinueDialogue();
            }
        }
    }



    public void OpenClosePanelDialogue(bool state)
    {
        panelDialogue.SetActive(state);
    }

    private void ConfigPanel(NPCDialogue npcDialogue)
    {
        OpenClosePanelDialogue(true);
        LoadDialogueSequence(npcDialogue);

        npcIcon.sprite = npcDialogue.Icon;
        npcNameTMP.text = $"{npcDialogue.Name}:";
        SHowTextWithAnimation(npcDialogue.Saludo);
    }

    private void LoadDialogueSequence(NPCDialogue npcDialogue)
    {
        if (npcDialogue.Conversacion == null || npcDialogue.Conversacion.Length <= 0)
        {
            return;
        }
        for (int i = 0; i < npcDialogue.Conversacion.Length; i++)
        {
            dialoguesSequence.Enqueue(npcDialogue.Conversacion[i].Oracion);
        }

    }

    private void ContinueDialogue()
    {
        if(NPCDisponible == null || despedidaDisplayed==true)
        {
            return;
        }
       if(dialoguesSequence.Count == 0)
        {
            string despedida = NPCDisponible.Dialogue.Despedida;
            SHowTextWithAnimation(despedida);
            despedidaDisplayed = true;
            return;
        }
        
        string nextDialogue = dialoguesSequence.Dequeue();
        SHowTextWithAnimation(nextDialogue);
    }



    private IEnumerator AnimateText(string oracion)
    {
        dialogueAnimated = false;
        npcConversationTMP.text = "";
        char[] letras = oracion.ToCharArray();
        for ( int i=0; i< letras.Length; i++)
        {
            npcConversationTMP.text += letras[i];
            yield return new WaitForSeconds(0.03f);
        }

        dialogueAnimated = true;
    }

    private void SHowTextWithAnimation(string oracion)
    {
        StartCoroutine(AnimateText(oracion));
    }
}
