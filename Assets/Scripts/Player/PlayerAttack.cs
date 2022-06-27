using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private PlayerStats stats;

    [Header("Pooler")]
    [SerializeField] private ObjectPooler pooler;

    [Header("Posiciones de Disparo")]
    [SerializeField] private Transform[] positionsShot;

    public Weapon WeaponEquiped { get; private set; }
    public EnemyInteraction TargetEnemy { get; private set; }

    private int indexDirectionShot;

    private void Update()
    {
        GetDirectionShot();
    }


    public void EquipWeapon(ItemWeapon weaponForEquip)
    {
        WeaponEquiped = weaponForEquip.weapon;
        if (WeaponEquiped.Type == TypeWeapon.Magia)
        {
            pooler.CreatePooler(WeaponEquiped.ProjectilePrefab.gameObject);
        }
        stats.AddBonusForWeapon(WeaponEquiped);
    }

    public void RemoveWeapon()
    {
        if (WeaponEquiped == null)
        {
            return;
        }
        if (WeaponEquiped.Type == TypeWeapon.Magia)
        {
            pooler.DestroyPooler();
        }

        stats.RemoveBonusForWeapon(WeaponEquiped);
        WeaponEquiped = null;
    }

    private void GetDirectionShot()
    {
        Vector2 input = new Vector2(x: Input.GetAxisRaw("Horizontal"), y: Input.GetAxisRaw("Vertical"));
        if (input.x > 0.1f)
        {
            indexDirectionShot = 1;
        }
        else if (input.x < 0f)
        {
            indexDirectionShot = 3;
        }
        else if (input.y > 0.1f)
        {
            indexDirectionShot = 0;
        }
        else if (input.y < 0f)
        {
            indexDirectionShot = 2;
        }
    }





    private void EnemyRangeSelected(EnemyInteraction enemySelected)
    {
        if (WeaponEquiped == null)  { return;}

        if (WeaponEquiped.Type != TypeWeapon.Magia) { return; }

        if (TargetEnemy == enemySelected) { return; }

        TargetEnemy = enemySelected;
        TargetEnemy.ShowEnemySelected(true,TypeDetection.Range);
    }

    private void EnemyNoSelected()
    {
        if (TargetEnemy == null) { return; }

        TargetEnemy.ShowEnemySelected(false, TypeDetection.Range);
        TargetEnemy = null;
    }

    private void EnemyMeleeDetected(EnemyInteraction enemyDetected)
    {
        if (WeaponEquiped == null) { return; }

        if (WeaponEquiped.Type != TypeWeapon.Melee) { return; }

        TargetEnemy = enemyDetected;
        TargetEnemy.ShowEnemySelected(true, TypeDetection.Melee);
    }

    private void EnemyMeleeLost()
    {
        if (WeaponEquiped == null) { return; }

        if (TargetEnemy == null) { return; }

        if (WeaponEquiped.Type != TypeWeapon.Melee) { return; }

        TargetEnemy.ShowEnemySelected(false, TypeDetection.Melee);
        TargetEnemy = null;
    }


    private void OnEnable()
    {
        SelectManager.EventEnemySelected += EnemyRangeSelected;
        SelectManager.EventObjectNoSelected += EnemyNoSelected;
        PlayerDetector.EventEnemyDetected += EnemyMeleeDetected;
        PlayerDetector.EventEnemyLost += EnemyMeleeLost;
    }

    private void OnDisable()
    {
        SelectManager.EventEnemySelected -= EnemyRangeSelected;
        SelectManager.EventObjectNoSelected -= EnemyNoSelected;
        PlayerDetector.EventEnemyDetected -= EnemyMeleeDetected;
        PlayerDetector.EventEnemyLost -= EnemyMeleeLost;
    }
}
