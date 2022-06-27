using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    public PlayerAttack PlayerAttack { get;private set; }

    private Rigidbody2D _rigidbody2D;
    private Vector2 direction;
    private EnemyInteraction targetEnemy;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (targetEnemy == null) { return; }

        MoveProjectile();
    }

    private void MoveProjectile()
    {
        direction = (targetEnemy.transform.position - transform.position);
        float angulo = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
        _rigidbody2D.MovePosition(_rigidbody2D.position + direction.normalized * speed * Time.fixedDeltaTime);
    }

    public void InitializeProjectile( PlayerAttack attack)
    {
        PlayerAttack = attack;
        targetEnemy = attack.TargetEnemy;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            float damage = PlayerAttack.GetDamage();
            targetEnemy.GetComponent<EnemyLife>().TakeDamage(damage);
            PlayerAttack.EventDamagedEnemy?.Invoke(damage);
            gameObject.SetActive(false);
        }
    }
}
