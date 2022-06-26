using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventoryUI : Singleton<InventoryUI>
{
    [Header("Panel Inventario Descripcion")]
    [SerializeField] private GameObject panelInventoryDescription;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;

    [SerializeField] private SlotInventory slotPrefab;
    [SerializeField] private Transform contenedor;


    public SlotInventory SlotSelected { get; private set; }
    List<SlotInventory> slotsDisponibles = new List<SlotInventory>();
    // Start is called before the first frame update
    void Start()
    {
        InitializeInventory();
    }

    private void Update()
    {
        UpgradeSlotSelected();
    }

    private void InitializeInventory()
    {
        for (int i = 0; i < Inventory.Instance.CantSlot; i++)
        {
           SlotInventory newSlot = Instantiate(slotPrefab, contenedor);
           newSlot.Index = i;
           slotsDisponibles.Add(newSlot);
        }
    }

    private void UpgradeSlotSelected()
    {
        GameObject goSelected = EventSystem.current.currentSelectedGameObject;
        if (goSelected == null) return;

        SlotInventory slot = goSelected.GetComponent<SlotInventory>();
        if(slot != null)
        {
            SlotSelected = slot;
        }
    }


    public void DrawItemInventory(InventoryItem itemForAdd, int cant , int itemIndex)
    {
        SlotInventory slot = slotsDisponibles[itemIndex];
        if (itemForAdd != null )
        {
            slot.ActiveSlotUI(true);
            slot.UpdateSlotUI(itemForAdd, cant);
        }
        else
        {
            slot.ActiveSlotUI(false);
        }
    }
    private void UpdateInventoryDescription(int index)
    {
        if (Inventory.Instance.ItemsInventory[index] != null)
        {
            itemIcon.sprite = Inventory.Instance.ItemsInventory[index].Icono;
            itemName.text = Inventory.Instance.ItemsInventory[index].Nombre;
            itemDescription.text = Inventory.Instance.ItemsInventory[index].Descripcion;
            panelInventoryDescription.SetActive(true);
        }
        else
        {
            panelInventoryDescription.SetActive(false);
        }
    }

    public void UseItem()
    {
        if(SlotSelected != null)
        {
            SlotSelected.UseItemSlot();
            SlotSelected.SelectSlot();
        }
    }

    public void EquipItem()
    {
        if (SlotSelected != null)
        {
            SlotSelected.EquipItemSlot();
            SlotSelected.SelectSlot();
        }
    }
    public void RemoveItem()
    {
        if (SlotSelected != null)
        {
            SlotSelected.RemoveItemSlot();
            SlotSelected.SelectSlot();
        }
    }

    #region Eventos
    private void SlotInteraccionRespuesta(TipoDeInteraccion tipo, int index)
    {
        if (tipo == TipoDeInteraccion.Click)
        {
            UpdateInventoryDescription(index);
        }
    }

    private void OnEnable()
    {
        SlotInventory.EventosSlotInteraccion += SlotInteraccionRespuesta;
    }

    private void OnDisable()
    {
        SlotInventory.EventosSlotInteraccion -= SlotInteraccionRespuesta;
    }
    #endregion




    
}
