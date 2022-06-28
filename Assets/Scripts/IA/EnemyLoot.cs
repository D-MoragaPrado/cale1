using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    [Header("Exp")]
    [SerializeField] private float expGanada;

    [Header("Loot")]
    [SerializeField] private DropItem[] lootDisponible;

    private List<DropItem> lootSeleccionado = new List<DropItem>();
    public List<DropItem> LootSeleccionado => lootSeleccionado;
    public float ExpGanada => expGanada;

    private void Start()
    {
        SelectLoot();
    }

    private void SelectLoot()
    {
        foreach (DropItem item in lootDisponible)
        {
            float probabilidad = Random.Range(0, 100);
            if (probabilidad <= item.PorcentajeDrop)
            {
                lootSeleccionado.Add(item);
            }
        }
    }
}
