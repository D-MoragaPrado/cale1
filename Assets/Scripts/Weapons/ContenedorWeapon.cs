using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContenedorWeapon : Singleton<ContenedorWeapon>
{
    [SerializeField] private Image weaponIcon;
    [SerializeField] private Image weaponSkillIcon;

    public ItemWeapon WeaponEquiped { get; set; }


    public void EquipWeapon(ItemWeapon itemWeapon)
    {
        WeaponEquiped = itemWeapon;
        weaponIcon.sprite = itemWeapon.weapon.WeaponIcon;
        weaponIcon.gameObject.SetActive(true);
        weaponSkillIcon.sprite = itemWeapon.weapon.IconSkill;
        if(weaponSkillIcon.sprite != null)
        {
            weaponSkillIcon.gameObject.SetActive(true);
        }
        Inventory.Instance.Player.PlayerAttack.EquipWeapon(itemWeapon);
    }

    public void RemoveWeapon()
    {
        weaponIcon.gameObject.SetActive(false);
        weaponSkillIcon.gameObject.SetActive(false);
        WeaponEquiped = null;
        Inventory.Instance.Player.PlayerAttack.RemoveWeapon();
    }
}
