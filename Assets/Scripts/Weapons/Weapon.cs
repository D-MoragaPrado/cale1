using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeWeapon
{
    Magia,
    Melee
}

[CreateAssetMenu(menuName ="Player/Weapon")]
public class Weapon : ScriptableObject
{
    [Header("Config")]
    public Sprite WeaponIcon;
    public Sprite IconSkill;
    public TypeWeapon Type;
    public float Damage;

    [Header("Magic Weapon")]
    public float ManaRequired;

    [Header("Stats")]
    public float ChanceCritic;
    public float ChanceBlock;


}
