using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static System.Action<float> EventDamagedEnemy;

    [Header("Stats")]
    [SerializeField] private PlayerStats stats;

    [Header("Pooler")]
    [SerializeField] private ObjectPooler pooler;

    [Header("Posiciones de Disparo")]
    [SerializeField] private Transform[] positionsShot;

    [Header("Ataque")]
    [SerializeField] private float timeBetweenAttack;

    public Weapon WeaponEquiped { get; private set; }
    public EnemyInteraction TargetEnemy { get; private set; }
    public bool Attacking { get; set; }


    private PlayerMana _playerMana;
    private int indexDirectionShot;
    private float timeForNextAttack;

    private void Awake()
    {
        _playerMana = GetComponent<PlayerMana>();
    }

    private void Update()
    {
        GetDirectionShot();
        if (Time.time > timeForNextAttack)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (WeaponEquiped == null || TargetEnemy == null) { return; }

                UseWeapon();
                timeForNextAttack = Time.time + timeBetweenAttack;
                StartCoroutine(IESetConditionAttack());
            }
        }
    }

    private void UseWeapon()
    {
        if (WeaponEquiped.Type == TypeWeapon.Magia)
        {
            if (_playerMana.Mana < WeaponEquiped.ManaRequired) { return;}

            GameObject newProjectile = pooler.GetInstance();
            newProjectile.transform.localPosition = positionsShot[indexDirectionShot].position;

            Projectile projectile = newProjectile.GetComponent<Projectile>();
            projectile.InitializeProjectile(this);

            newProjectile.SetActive(true);
            _playerMana.UseMana(WeaponEquiped.ManaRequired);
        }
        else
        {
            float damage = GetDamage();
            EnemyLife enemyLife = TargetEnemy.GetComponent<EnemyLife>();
            enemyLife.TakeDamage( damage );
            EventDamagedEnemy?.Invoke(damage);
        }
    }

    public float GetDamage()
    {
        float cant = stats.damage;
        if(Random.value < stats.percentageCritical / 100)
        {
            cant *= 2;
        }

        return cant;
    }



    private IEnumerator IESetConditionAttack()
    {
        Attacking = true;
        yield return new WaitForSeconds(0.3f);
        Attacking = false;
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
