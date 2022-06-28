using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : Singleton<LootManager>

{

    [Header("Config")]
    [SerializeField] private GameObject panelLoot;
    [SerializeField] private LootButton lootButtonPrefab;
    [SerializeField] private Transform lootContenedor;

    
   public void ShowLoot(EnemyLoot enemyLoot)
    {
        panelLoot.SetActive(true);
        if (ContenedorOcupado())
        {
            foreach (Transform hijo in lootContenedor.transform)
            {
                Destroy(hijo.gameObject);
            }
        }

        for (int i = 0; i < enemyLoot.LootSeleccionado.Count; i++)
        {
            CargarLootPanel(enemyLoot.LootSeleccionado[i]);
        }
    }
    
    public void ClosePanel()
    {
        panelLoot.SetActive(false);
    } 
    
    private void CargarLootPanel(DropItem dropItem)
    {
        if (dropItem.ItemRecogido)
        {
            return;
        }

        LootButton loot = Instantiate(lootButtonPrefab, lootContenedor);
        loot.ConfigLootItem(dropItem);
        loot.transform.SetParent(lootContenedor);
    }
    
    private bool ContenedorOcupado()
    {
        LootButton[] hijos = lootContenedor.GetComponentsInChildren<LootButton>();
        if (hijos.Length > 0)
        {
            return true;
        }

        return false;
    }  
     
}
