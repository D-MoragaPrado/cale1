using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/Weapon")]
public class ItemWeapon : InventoryItem
{
    [Header("Weapon")]
    public Weapon weapon;

    public override bool EquipItem()
    {
        if(ContenedorWeapon.Instance.WeaponEquiped != null)
        {
            return false;
        }

        ContenedorWeapon.Instance.EquipWeapon(this);
        return true;
    }

    public override bool RemoveItem()
    {
        if (ContenedorWeapon.Instance.WeaponEquiped == null)
        {
            return false;
        }
        ContenedorWeapon.Instance.RemoveWeapon();
        return true;
    }
}
