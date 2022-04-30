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
}
