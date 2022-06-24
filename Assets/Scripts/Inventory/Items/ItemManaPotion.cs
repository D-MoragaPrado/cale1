
using UnityEngine;

[CreateAssetMenu(menuName = "Items/PotionMana")]
public class ItemManaPotion : InventoryItem
{

    [Header("pocion info")]
    public float ManaRestore;



    public override bool UseItem()
    {
        if (Inventory.Instance.Player.PlayerMana.CanBeRestore)
        {
            Inventory.Instance.Player.PlayerMana.RestoreMana(ManaRestore);
            return true;
        }
        return false;
    }
}
