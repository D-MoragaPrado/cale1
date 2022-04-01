using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform respawnPoint;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {      
            if (player.PlayerLife.PlayerDefeated)
            {
                player.transform.localPosition = respawnPoint.position;
                player.RevivePlayer();

            }
        }
    }
}
