using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;

    public PlayerAttack PlayerAttack{ get; private set; }
    public PlayerExperience PlayerExperience { get;private set; }
    public PlayerLife PlayerLife { get; private set; }
    public PlayerMana PlayerMana { get; private set; }
    public PlayerAnimations PlayerAnimations { get; private set; }
    

    

    private void Awake()
    {
        PlayerAttack = GetComponent<PlayerAttack>();
        PlayerExperience = GetComponent<PlayerExperience>();
        PlayerLife = GetComponent<PlayerLife>();
        PlayerAnimations = GetComponent<PlayerAnimations>();
        PlayerMana = GetComponent<PlayerMana>();


    }

    public void RevivePlayer()
    {
        PlayerLife.RevivePlayer();
        PlayerAnimations.RevivePlayer();
        PlayerMana.RestoreMana();

    }
}
