using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public enum TipoDeInteraccion
{
    Click,
    Usar,
    Equipar,
    Remover
}

public class SlotInventory : MonoBehaviour
{

    public static Action<TipoDeInteraccion, int> EventosSlotInteraccion;

    [SerializeField] private Image itemIcon;
    [SerializeField] private GameObject fondoCantidad;
    [SerializeField] private TextMeshProUGUI cantTMP;

    public int Index { get; set; }

    private Button _button;
    
    public void UpdateSlotUI(InventoryItem item, int cant)
    {
        itemIcon.sprite = item.Icono;
        cantTMP.text = cant.ToString();
    }

    public void ActiveSlotUI ( bool state)
    {
        itemIcon.gameObject.SetActive(state);
        fondoCantidad.SetActive(state);
    }

    public void SelectSlot()
    {
        _button.Select();
    }


    public void ClickSlot()
    {
        EventosSlotInteraccion?.Invoke(TipoDeInteraccion.Click, Index);
    }

    public void UseItemSlot()
    {
        if (Inventory.Instance.ItemsInventory[Index] != null)
        {
            EventosSlotInteraccion?.Invoke(TipoDeInteraccion.Usar, Index);
        }
    }


    public void EquipItemSlot()
    {
        if (Inventory.Instance.ItemsInventory[Index] != null)
        {
            EventosSlotInteraccion?.Invoke(TipoDeInteraccion.Equipar, Index);
        }
    }

    public void RemoveItemSlot()
    {
        if (Inventory.Instance.ItemsInventory[Index] != null)
        {
            EventosSlotInteraccion?.Invoke(TipoDeInteraccion.Remover, Index);
        }
    }
}
