using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject npcButtonInteract;
    [SerializeField] private NPCDialogue npcDialogue;
    public NPCDialogue Dialogue => npcDialogue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueManager.Instance.NPCDisponible = this;
            npcButtonInteract.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueManager.Instance.NPCDisponible = null;
            npcButtonInteract.SetActive(false);
        }
    }
}
