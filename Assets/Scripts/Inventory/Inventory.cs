using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private int cantSlot;
    public int CantSlot => cantSlot;

    [Header("Items")]
    [SerializeField] private InventoryItem[] itemsInventory;


    private void Start()
    {
        itemsInventory = new InventoryItem[cantSlot];
    }

    public void AddItem(InventoryItem itemForAdd, int cant)
    {
        if( itemForAdd == null) { return; }
        if(cant<= 0) { return; }
        //verificar si ya existe uno
        //List<int> indexes = VerifyExistence(itemForAdd.Id); //ta fallando aqui


        if (cant > itemForAdd.AcumulacionMax)
        {
            AddItemInSlot(itemForAdd, itemForAdd.AcumulacionMax);
            cant -= itemForAdd.AcumulacionMax;
            AddItem(itemForAdd, cant);
        }
        else
        {
            AddItemInSlot(itemForAdd, cant);
        }
    }

    private List<int> VerifyExistence (string itemId)
    {
        List<int> indexsItems = new List<int>();
        for (int i = 0; i < itemsInventory.Length; i++)
        {
            Debug.Log(itemsInventory[i].Id);
            if (itemsInventory[i].Id != null)
            {
                if (itemsInventory[i].Id == itemId)
                {
                    indexsItems.Add(i);
                }
            }
            
        }
        return indexsItems;
    }

    private void AddItemInSlot(InventoryItem item , int cantidad)
    {
        for (int i = 0; i < itemsInventory.Length; i++)
        {
            if (itemsInventory[i] == null)
            {
                itemsInventory[i] = item.CopyItem();
                itemsInventory[i].Cant = cantidad;
                return;
            }
        }
    }
}