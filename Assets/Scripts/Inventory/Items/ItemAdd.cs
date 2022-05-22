using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAdd : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private InventoryItem inventoryItemReference;
    [SerializeField] private int cantForAdd;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.Instance.AddItem(inventoryItemReference, cantForAdd);
            Destroy(gameObject);
        }
    }

}
