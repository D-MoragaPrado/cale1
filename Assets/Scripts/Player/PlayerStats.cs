using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Stats")]
public class PlayerStats : ScriptableObject
{
    public float damage;
    public float defense;
    public float speed;
    public float level;
    public float actualExp;
    public float expRequiredNextLevel;
    [Range(0f,100f)] public float percentageCritical;
    [Range(0f, 100f)] public float percentageBlocking;
    public float actualExpTemp;


    public void AddBonusForWeapon(Weapon weapon)
    {
        damage += weapon.Damage;
        percentageCritical += weapon.ChanceCritic;
        percentageBlocking += weapon.ChanceBlock;
    }

    public void RemoveBonusForWeapon(Weapon weapon)
    {
        damage -= weapon.Damage;
        percentageCritical -= weapon.ChanceCritic;
        percentageBlocking -= weapon.ChanceBlock;
    }


    public void ResetValues()
    {
        damage = 5f ;
        defense = 2f;
        speed = 100f;
        level = 1;
        actualExp = 0f;
        expRequiredNextLevel = 2f;
        percentageCritical = 0f;
        percentageBlocking = 0f;
    }

    public void LevelStats()
    {
        damage += 5f;
        defense += 2f;
        speed += 5f;
        percentageCritical += 3f;
        percentageBlocking += 3f;
    }
}
