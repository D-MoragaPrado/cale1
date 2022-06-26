using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon WeaponEquiped { get;private set; }


    public void EquipWeapon(ItemWeapon weaponForEquip)
    {
        WeaponEquiped = weaponForEquip.weapon;
    }

    public void RemoveWeapon()
    {
        if (WeaponEquiped == null)
        {
            return;
        }
        WeaponEquiped = null;


    }
}
