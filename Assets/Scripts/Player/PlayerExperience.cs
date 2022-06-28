using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private PlayerStats stats;

    [Header("Config")]
    [SerializeField] private int levelMax;
    [SerializeField] private int expBase;
    [SerializeField] private int IncrementalValue;


    private float expActual;
    private float expActualTemp;
    private float expRequiredNextLevel;

    // Start is called before the first frame update
    void Start()
    {
        //stats.level= 1;
        //expRequiredNextLevel = expBase;
        expRequiredNextLevel = stats.expRequiredNextLevel;
        expActualTemp = stats.actualExpTemp;
        //stats.expRequiredNextLevel = expRequiredNextLevel;
        UpdateExpBar();
    }

    public void AddExperience(float expGained)
    {
        if( expGained > 0f)
        {
            float expMissingNextLevel = expRequiredNextLevel - expActualTemp;
            expActual += expGained;
            if ( expGained >= expMissingNextLevel)
            {
                expGained -= expMissingNextLevel;
                UpdateLevel();
                AddExperience(expGained);
            }
            else
            {
                expActualTemp += expGained;
                if( expActualTemp == expRequiredNextLevel)
                {
                    UpdateLevel();
                }
            }
        }
        stats.actualExp = expActual;
        stats.actualExpTemp = expActualTemp;
        UpdateExpBar();
    }

    private void UpdateLevel()
    {
        if (stats.level < levelMax)
        {
            stats.level++;
            expActualTemp = 0f;
            expRequiredNextLevel *= IncrementalValue;
            stats.expRequiredNextLevel = expRequiredNextLevel;
            stats.LevelStats();
        }
    }


    private void UpdateExpBar()
    {
        UIManager.Instance.UpdateExperiencePlayer(expActualTemp, expRequiredNextLevel);
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddExperience(2f);
        }
    }*/


    private void ResponceEnemyDefeated(float exp)
    {
        AddExperience(exp);
    }


    private void OnEnable()
    {
        EnemyLife.EventEnemyDefeated += ResponceEnemyDefeated;
    }

    private void OnDisable()
    {
        EnemyLife.EventEnemyDefeated -= ResponceEnemyDefeated;
    }
}
