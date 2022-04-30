using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerLife PlayerLife { get; private set; }
    public PlayerMana PlayerMana { get; private set; }
    public PlayerAnimations PlayerAnimations { get; private set; }
    

    

    private void Awake()
    {
        PlayerLife = GetComponent<PlayerLife>();
        PlayerAnimations = GetComponent<PlayerAnimations>();
    }

    public void RevivePlayer()
    {
        PlayerLife.RevivePlayer();
        PlayerAnimations.RevivePlayer();
        PlayerMana.RestoreMana();

    }
}
