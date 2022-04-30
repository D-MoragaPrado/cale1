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


    private float expActualTemp;
    private float expRequiredNextLevel;

    // Start is called before the first frame update
    void Start()
    {
        stats.level= 1;
        expRequiredNextLevel = expBase;
        UpdateExpBar();
    }

    public void AddExperience(float expGained)
    {
        if( expGained > 0f)
        {
            float expMissingNextLevel = expRequiredNextLevel - expActualTemp;
            if( expGained >= expMissingNextLevel)
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
        UpdateExpBar();
    }

    private void UpdateLevel()
    {
        if (stats.level < levelMax)
        {
            stats.level++;
            expActualTemp = 0f;
            expRequiredNextLevel *= IncrementalValue;
        }
    }


    private void UpdateExpBar()
    {
        UIManager.Instance.UpdateExperiencePlayer(expActualTemp, expRequiredNextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
