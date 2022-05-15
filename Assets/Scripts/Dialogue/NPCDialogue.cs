using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionExtraNPC
{
    Quests,
    Tienda,
    Crafting
}


[CreateAssetMenu]
public class NPCDialogue : ScriptableObject
{
    [Header("Inf")]
    public string Name;
    public Sprite Icon;
    public bool contExtraInteraction;
    public InteractionExtraNPC InteractionExtra;


    [Header("Saludo")]
    [TextArea] public string Saludo;

    [Header("Chat")]
    public DialogueText[] Conversacion;


    [Header("Despedida")]
    [TextArea] public string Despedida;

}
[Serializable]
public class DialogueText
{
    [TextArea] public string Oracion;
}