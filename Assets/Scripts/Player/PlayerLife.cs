using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : BaseLife
{
    public static Action EventPlayerDefeated;
    public bool CanBeCured => Health < maxHealth;

    public bool PlayerDefeated { get; private set; }

    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }


    protected override void Start()
    {
        base.Start();
        UpdateLifeBar(Health, maxHealth);
    }



    private void Update()  // solo para probar
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestoreHealth(10);
        }
        
    }



    public void RestoreHealth (float cant)
    {
        if (PlayerDefeated)
        {
            return;
        }
        if (CanBeCured)
        {
            Health += cant;
            if (Health > maxHealth)
            {
                Health = maxHealth;
            }

            UpdateLifeBar(Health, maxHealth);
        }
    }

    protected override void PlayerDead()
    {
        _boxCollider2D.enabled = false;
        PlayerDefeated = true;
        EventPlayerDefeated?.Invoke(); // si el evento no es nulo , lo invocamos
        
    }

    public void RevivePlayer()
    {
        _boxCollider2D.enabled = true;
        PlayerDefeated = false;
        Health = initialHealth;
        UpdateLifeBar(Health, initialHealth);

    }

    protected override void UpdateLifeBar(float actualLife, float maxHealth)
    {
        UIManager.Instance.UpdateLifePlayer(actualLife , maxHealth);

    }
}
