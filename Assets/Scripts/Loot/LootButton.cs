using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LootButton : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;

    public DropItem ItemPorRecoger { get; set; }

    public void ConfigLootItem(DropItem dropItem)
    {
        ItemPorRecoger = dropItem;
        itemIcon.sprite = dropItem.Item.Icono;
        itemName.text = $"{dropItem.Item.Nombre} x{dropItem.Cant}";
    }

    public void CollectItem()
    {
        if (ItemPorRecoger == null)
        {
            return;
        }

        Inventory.Instance.AddItem(ItemPorRecoger.Item, ItemPorRecoger.Cant);
        ItemPorRecoger.ItemRecogido = true;
        Destroy(gameObject);
    }
}
