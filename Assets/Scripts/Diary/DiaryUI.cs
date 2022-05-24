using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiaryUI : Singleton<DiaryUI>
{
    [Header("Panel Inventario Descripcion")]
    [SerializeField] private GameObject panelDiaryDescription;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemTipe;
    [SerializeField] private TextMeshProUGUI itemDescription;

    [SerializeField] private SlotDiary slotPrefab;
    [SerializeField] private Transform contenedor;
    
    List<SlotDiary> slotsDisponibles = new List<SlotDiary>();
    // Start is called before the first frame update
    void Start()
    {
        InitializeDiary();
    }

    private void InitializeDiary()
    {
        for (int i = 0; i < Diary.Instance.CantSlot; i++) 
        {
            SlotDiary newSlot = Instantiate(slotPrefab, contenedor);
            newSlot.Index = i;
            slotsDisponibles.Add(newSlot);
        }
    }

    public void DrawItemDiary(DiaryPersonaje itemForAdd, int itemIndex)
    {
        SlotDiary slot = slotsDisponibles[itemIndex];
        if (itemForAdd != null)
        {
            slot.ActiveSlotUI(true);
            slot.UpdateSlotUI(itemForAdd);
        }
        else
        {
            slot.ActiveSlotUI(false);
        }
    }

    private void UpdateDiaryDescription(int index)
    {
        if (Diary.Instance.ItemsDiary[index] != null) 
        {
            itemIcon.sprite = Diary.Instance.ItemsDiary[index].Icono;
            itemName.text = Diary.Instance.ItemsDiary[index].Nombre;
            itemDescription.text = Diary.Instance.ItemsDiary[index].Descripcion;
            itemTipe.text = Diary.Instance.ItemsDiary[index].tipo;
        panelDiaryDescription.SetActive(true);
        }
        else
        {
            panelDiaryDescription.SetActive(false);
        }
    }


    private void SlotInterraccionRespuesta(int index)
    {
        UpdateDiaryDescription(index);

    }

    private void OnEnable()
    {
        SlotDiary.EventosDiaryInteraccion += SlotInterraccionRespuesta;
    }

    private void OnDisable()
    {
        SlotDiary.EventosDiaryInteraccion -= SlotInterraccionRespuesta;
    }
}
