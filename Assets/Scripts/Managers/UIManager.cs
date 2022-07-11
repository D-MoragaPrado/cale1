using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Stats")]   
    [SerializeField] private PlayerStats stats;

    [Header("Panels")]   
    [SerializeField] private GameObject panelStats;
    [SerializeField] private GameObject panelInventory;
    [SerializeField] private GameObject panelDiary;
    [SerializeField] private GameObject panelMachiQuests;
    [SerializeField] private GameObject panelPlayerQuests;
    [SerializeField] private GameObject panelDead;
    [SerializeField] private GameObject panelMap;


    [Header("Barra")]   //la barrita de color
    [SerializeField] private Image PlayerLife;           
    [SerializeField] private Image PlayerMana;
    [SerializeField] private Image PlayerExp;

    [Header("Text")]   // el texto 100/100
    [SerializeField] private TMPro.TextMeshProUGUI lifeTMP;    
    [SerializeField] private TMPro.TextMeshProUGUI manaTMP;
    [SerializeField] private TMPro.TextMeshProUGUI expTMP;
    [SerializeField] private TMPro.TextMeshProUGUI levelTMP;

    [Header("Stats")]
    [SerializeField] private TMPro.TextMeshProUGUI statDamageTMP;
    [SerializeField] private TMPro.TextMeshProUGUI statDefenseTMP;
    [SerializeField] private TMPro.TextMeshProUGUI statCriticTMP;
    [SerializeField] private TMPro.TextMeshProUGUI statBlockTMP;
    [SerializeField] private TMPro.TextMeshProUGUI statSpeedTMP;
    [SerializeField] private TMPro.TextMeshProUGUI statLevelTMP;
    [SerializeField] private TMPro.TextMeshProUGUI statActualExpTMP;
    [SerializeField] private TMPro.TextMeshProUGUI statExpRequiredNextLevelTMP;


    private float actualHealth;
    private float maxHealth;

    private float actualMana;
    private float maxMana;

    private float actualExp;
    private float expRequiredNextLevel;



    // Update is called once per frame
    void Update()
    {
        UpdateUIPlayer();
        UpdatePanelStats();

        if (Input.GetKeyDown(KeyCode.M))
        {
            OpenClosePanelMap();
        }
    }

    private void UpdateUIPlayer()
    {
        PlayerLife.fillAmount = Mathf.Lerp(PlayerLife.fillAmount, actualHealth / maxHealth, 10f * Time.deltaTime); //barra modificada
        lifeTMP.text = $"{actualHealth}/{maxHealth}"; //texto actualizado

        PlayerMana.fillAmount = Mathf.Lerp(PlayerMana.fillAmount, actualMana / maxMana, 10f * Time.deltaTime); //barra modificada
        manaTMP.text = $"{actualMana}/{maxMana}"; //texto actualizado

        PlayerExp.fillAmount = Mathf.Lerp(PlayerExp.fillAmount, actualExp / expRequiredNextLevel, 10f * Time.deltaTime); //barra modificada
        expTMP.text = $"{((actualExp / expRequiredNextLevel)*100):F2}%"; //texto con 2 decimales

        levelTMP.text = $"Nivel {stats.level}";

    }

    private void UpdatePanelStats()
    {
        if (panelStats.activeSelf == false)
        {
            return;
        }

        statDamageTMP.text = stats.damage.ToString();
        statDefenseTMP.text = stats.defense.ToString();
        statCriticTMP.text = $"{stats.percentageCritical}%";
        statBlockTMP.text = $"{stats.percentageBlocking}%";
        statSpeedTMP.text = stats.speed.ToString();
        statLevelTMP.text = stats.level.ToString();
        statActualExpTMP.text = stats.actualExpTemp.ToString();
        statExpRequiredNextLevelTMP.text = stats.expRequiredNextLevel.ToString();


    }




    public void UpdateLifePlayer(float pActualHealth , float pMaxHealth)
    {
        actualHealth = pActualHealth;
        maxHealth = pMaxHealth;
    }

    public void UpdateManaPlayer(float pActualMana, float pMaxMana)
    {
        actualMana = pActualMana;
        maxMana = pMaxMana;
    }

    public void UpdateExperiencePlayer(float pActualExp, float pRequiredExp)
    {
        actualExp = pActualExp;
        expRequiredNextLevel = pRequiredExp;
    }

    #region Panels

    public void OpenClosePanelStats()
    {
        panelStats.SetActive(!panelStats.activeSelf);
        panelDiary.SetActive(false);
        panelInventory.SetActive(false);
        panelPlayerQuests.SetActive(false);
        panelMap.SetActive(false);
    }

    public void OpenClosePanelInventory()
    {
        panelInventory.SetActive(!panelInventory.activeSelf);
        panelDiary.SetActive(false);
        panelStats.SetActive(false);
        panelPlayerQuests.SetActive(false);
        panelMap.SetActive(false);
    }

    public void OpenClosePanelDiary()
    {
        panelDiary.SetActive(!panelDiary.activeSelf);
        panelStats.SetActive(false);
        panelInventory.SetActive(false);
        panelPlayerQuests.SetActive(false);
        panelMap.SetActive(false);
    }

    public void OpenClosePanelMachiQuests()
    {
        panelMachiQuests.SetActive(!panelMachiQuests.activeSelf);
        panelStats.SetActive(false);
        panelInventory.SetActive(false);
        panelDiary.SetActive(false);
        panelPlayerQuests.SetActive(false);
        panelMap.SetActive(false);
    }
    //panelPlayerQuests.SetActive(false);
    public void OpenClosePanelPlayerQuests()
    {
        panelPlayerQuests.SetActive(!panelPlayerQuests.activeSelf);
        panelStats.SetActive(false);
        panelInventory.SetActive(false);
        panelDiary.SetActive(false);
        panelMap.SetActive(false);
    }

    public void OpenClosePanelDead()
    {
        panelDead.SetActive(!panelDead.activeSelf);
        panelStats.SetActive(false);
        panelInventory.SetActive(false);
        panelDiary.SetActive(false);
        panelPlayerQuests.SetActive(false);
        panelMap.SetActive(false);
    }


    public void OpenClosePanelMap()
    {
        panelMap.SetActive(!panelMap.activeSelf);
        panelStats.SetActive(false);
        panelInventory.SetActive(false);
        panelDiary.SetActive(false);
        panelPlayerQuests.SetActive(false);
    }

    public void OpenPanelInteraction(InteractionExtraNPC tipoInteraction)
    {
        switch (tipoInteraction)
        {
            case InteractionExtraNPC.Quests:
                OpenClosePanelMachiQuests();
                break;
            case InteractionExtraNPC.Tienda:
                break;
            case InteractionExtraNPC.Crafting:
                break;
            default:
                break;
        }
    }
    #endregion
}
