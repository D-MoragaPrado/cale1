using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{

    public static Action<EnemyInteraction> EventEnemySelected;
    public static Action EventObjectNoSelected;

    public EnemyInteraction EnemySelected { get; set; }
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        SelectEnemy();
    }

    private void SelectEnemy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 
                Mathf.Infinity, LayerMask.GetMask("Enemy"));
            if(hit.collider != null)
            {              
                EnemySelected = hit.collider.GetComponent<EnemyInteraction>();
                EnemyLife enemyLife = EnemySelected.GetComponent<EnemyLife>();

                if (enemyLife.Health > 0f)
                {
                    EventEnemySelected?.Invoke(EnemySelected);
                }
                else
                {
                    EnemyLoot loot = EnemySelected.GetComponent<EnemyLoot>();
                    LootManager.Instance.ShowLoot(loot);
                }
                
            }
            else
            {
                EventObjectNoSelected?.Invoke();
            }
        }
    }
}
