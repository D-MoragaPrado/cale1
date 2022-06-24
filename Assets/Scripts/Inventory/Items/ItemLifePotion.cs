

using UnityEngine;

[CreateAssetMenu(menuName ="Items/PotionLife")]
public class ItemLifePotion : InventoryItem
{
    [Header("pocion info")]
    public float HPRestore;



    public override bool UseItem()
    {
        if (Inventory.Instance.Player.PlayerLife.CanBeCured)
        {
            Inventory.Instance.Player.PlayerLife.RestoreHealth(HPRestore);
            return true;
        }
        return false;
    }
}
