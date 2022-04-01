using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   //private PlayerLife _playerLife;
    public PlayerLife PlayerLife { get; private set; }
    public PlayerAnimations PlayerAnimations { get; private set; }
    //public PlayerAnimations _playerAnimations;

    private void Awake()
    {
        PlayerLife = GetComponent<PlayerLife>();
        PlayerAnimations = GetComponent<PlayerAnimations>();
    }

    public void RevivePlayer()
    {
        PlayerLife.RevivePlayer();
        PlayerAnimations.RevivePlayer();

    }
}
