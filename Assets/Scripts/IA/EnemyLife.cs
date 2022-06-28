using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyLife : BaseLife
{
    public static Action<float> EventEnemyDefeated;

    [Header("Vida")]
    [SerializeField] private EnemyLifeBar barLifePrefab;
    [SerializeField] private Transform barLifePosition;

    [Header("Rastros")]
    [SerializeField] private GameObject rastros;
    [SerializeField] private string nameMision;


    private EnemyLifeBar _enemyLifeBarCreated;
    private EnemyInteraction _enemyInteraction;
    private EnemyMovement _enemyMovement;
    private EnemyLoot _enemyLoot;
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
        _enemyLoot = GetComponent<EnemyLoot>();
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
        EventEnemyDefeated?.Invoke(_enemyLoot.ExpGanada);
        DisableEnemy();
        QuestManager.Instance.AddProgress(nameMision, 1);
    }


    private void DisableEnemy()
    {
        rastros.SetActive(true);
        _enemyLifeBarCreated.gameObject.SetActive(false);
        _spriteRenderer.enabled = false;
        _enemyMovement.enabled = false;
        _waypointMovement.enabled = false;
        _controller.enabled = false;
        _boxCollider2D.isTrigger = true;
        _enemyInteraction.DisableSpriteSelect();
        
    }
}
