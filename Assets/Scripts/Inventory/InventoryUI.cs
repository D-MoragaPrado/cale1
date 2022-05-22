using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private SlotInventory slotPrefab;
    [SerializeField] private Transform contenedor;

    List<SlotInventory> slotsDisponibles = new List<SlotInventory>();
    // Start is called before the first frame update
    void Start()
    {
        
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
}
