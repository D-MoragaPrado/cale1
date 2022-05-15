using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] protected private float initialMana;
    [SerializeField] protected private float maxMana;
    [SerializeField] protected private float regenerationForSecond;

    public float Mana { get; private set; }


    private PlayerLife _playerLife;

   private void Awake()
    {
        _playerLife = GetComponent<PlayerLife>();
    }



    void Start()
    {
        Mana = initialMana;
        UpdateManaBar();
        InvokeRepeating(nameof(RegenerateMana), 1, 1);  // funcion , repetir 1 vez , cada 1 segundo
    }

    public void UseMana(float cant)
    {
        if(Mana >= cant)
        {
            Mana -= cant;
        }
        UpdateManaBar();
    }

    private void RegenerateMana()
    {
        if ((_playerLife.Health > 0f) && (Mana < maxMana))
        {
            Mana += regenerationForSecond;
            UpdateManaBar();
        }
    }

    public void RestoreMana()
    {
        Mana = initialMana;

    }



    private void UpdateManaBar()
    {
        UIManager.Instance.UpdateManaPlayer(Mana, maxMana);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UseMana(10);
        }

        
    }
}
