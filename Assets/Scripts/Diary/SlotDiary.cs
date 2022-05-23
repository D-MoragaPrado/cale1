using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SlotDiary : MonoBehaviour   
{
    public static Action< int> EventosDiaryInteraccion; 

    [SerializeField] private TextMeshProUGUI nombreTMP;
    [SerializeField] private GameObject fondoNombre;

    public int Index { get; set; }

    public void UpdateSlotUI(DiaryPersonaje personaje)
    {
        nombreTMP.text = personaje.Nombre;

    }

    public void ActiveSlotUI(bool state)
    {
        fondoNombre.SetActive(state);
    }

    public void ClickSlot()
    {
        EventosDiaryInteraccion?.Invoke( Index);
    }
}
