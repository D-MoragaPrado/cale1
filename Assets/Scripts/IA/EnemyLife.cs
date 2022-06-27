using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : BaseLife
{
    [SerializeField] private EnemyLifeBar barLifePrefab;
    [SerializeField] private Transform barLifePosition;

    private EnemyLifeBar _enemyLifeBarCreated;
    private EnemyInteraction _enemyInteraction;
    private EnemyMovement _enemyMovement;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2D;
    private IAController _controller;
    private WaypointMovement _waypointMovement;


    private void Awake()
    {
        _enemyInteraction = GetComponent<EnemyInteraction>();
        _enemyMovement = GetComponent<EnemyMovement>();
        _waypointMovement = GetComponent<WaypointMovement>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _controller = GetComponent<IAController>();
    }

    protected override void Start()
    {
        base.Start();
        CreateBarLife();
    }

    private void CreateBarLife()
    {
        _enemyLifeBarCreated = Instantiate(barLifePrefab, barLifePosition);
        UpdateLifeBar(Health, maxHealth);
    }

    protected override void UpdateLifeBar(float actualLife, float maxHealth)
    {
        _enemyLifeBarCreated.ModifyHealth(actualLife, maxHealth);
    }

    protected override void PlayerDead()
    {
        DisableEnemy();
    }


    private void DisableEnemy()
    {
        _enemyLifeBarCreated.gameObject.SetActive(false);
        _spriteRenderer.enabled = false;
        _enemyMovement.enabled = false;
        _waypointMovement.enabled = false;
        _controller.enabled = false;
        _boxCollider2D.isTrigger = true;
        _enemyInteraction.DisableSpriteSelect();
        
    }
}
