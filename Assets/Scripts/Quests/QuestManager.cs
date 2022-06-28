using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestManager : Singleton<QuestManager>
{
    [Header("Personaje")]
    [SerializeField] private Player player;

    [Header("Quests")]
    [SerializeField] private Quest[] questDisponibles;

    [Header("Machi Quests")]
    [SerializeField] private MachiQuestDescription machiQuestPrefab;
    [SerializeField] private Transform machiQuestContenedor;

    [Header("Personaje Quests")]
    [SerializeField] private PlayerQuestDescription playerQuestPrefab;
    [SerializeField] private Transform playerQuestContenedor;

    [Header("Panel Quest Completado")]
    [SerializeField] private GameObject panelQuestCompleted;
    [SerializeField] private TextMeshProUGUI questNombre;
    [SerializeField] private TextMeshProUGUI questRecompensaOro;
    [SerializeField] private TextMeshProUGUI questRecompensaExp;
    [SerializeField] private TextMeshProUGUI questRecompensaItemCantidad;
    [SerializeField] private Image questRecompensaItemIcono;

    public Quest QuestForClaim { get; private set; }

    private void Start()
    {
        LoadQuestInMachi();
    }
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddProgress("pincoya", 1);

        }
    }*/
    private void LoadQuestInMachi()
    {
        for (int i = 0; i < questDisponibles.Length; i++)
        {
            MachiQuestDescription newQuest = Instantiate(machiQuestPrefab, machiQuestContenedor);
            newQuest.ConfQuestUI(questDisponibles[i]);
        }
    }


    private void AddQuestForComplete(Quest questForComplete)
    {
        PlayerQuestDescription nuevoQuest = Instantiate(playerQuestPrefab, playerQuestContenedor);
        nuevoQuest.ConfQuestUI(questForComplete);
    }

    public void AddQuest(Quest questForComplete)
    {
        AddQuestForComplete(questForComplete);
    }


    public void ClaimReward()
    {
        if (QuestForClaim == null)
        {
            return;
        }

        //MonedasManager.Instance.AñadirMonedas(QuestPorReclamar.RecompensaOro);
        player.PlayerExperience.AddExperience(QuestForClaim.RecompensaExp);
        Inventory.Instance.AddItem(QuestForClaim.RecompensaItem.item, QuestForClaim.RecompensaItem.Cantidad);
        panelQuestCompleted.SetActive(false);
        QuestForClaim = null;
    }
    
    public void AddProgress(string questID, int cant)
    {
        Quest questForActualize = QuestExists(questID);
        questForActualize.AddProgress(cant);
    }
    
    private Quest QuestExists(string questID)
    {
        for (int i = 0; i < questDisponibles.Length; i++)
        {
            if (questDisponibles[i].ID == questID)
            {
                return questDisponibles[i];
            }
        }

        return null;
    }
    
    private void ShowQuestCompleted(Quest questCompleted)
    {
        panelQuestCompleted.SetActive(true);
        questNombre.text = questCompleted.Nombre;
        questRecompensaOro.text = questCompleted.RecompensaOro.ToString();
        questRecompensaExp.text = questCompleted.RecompensaExp.ToString();
        questRecompensaItemCantidad.text = questCompleted.RecompensaItem.Cantidad.ToString();
        questRecompensaItemIcono.sprite = questCompleted.RecompensaItem.item.Icono;
    }
    
    
    private void QuestCompletedResponse(Quest questCompleted)
    {
        QuestForClaim = QuestExists(questCompleted.ID);
        if (QuestForClaim != null)
        {
            ShowQuestCompleted(QuestForClaim);
        }
    }
    
    private void OnEnable()
    {
        Quest.EventQuestCompleted += QuestCompletedResponse;
    }

    private void OnDisable()
    {
        Quest.EventQuestCompleted -= QuestCompletedResponse;
    }
}
