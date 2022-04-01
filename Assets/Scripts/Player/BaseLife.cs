using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLife : MonoBehaviour
{
    [SerializeField] protected private float initialHealth;
    [SerializeField] protected private float maxHealth;


    public float Health{ get; protected  set; }
    
    protected virtual void Start()
    {
        Health = initialHealth;
    }

    public void TakeDamage(float quantity)
    {
        if(quantity <= 0f)
        {
            return;
        }

        if(Health > 0f)
        {
            Health -= quantity;
            UpdateLifeBar(Health, maxHealth);

            if (Health <= 0f)
            {
                UpdateLifeBar(Health, maxHealth);
                PlayerDead();
            }
        }

    }

    protected virtual void UpdateLifeBar(float actualLife , float maxHealth)
    {

    }

    protected virtual void PlayerDead()
    {

    }


}
