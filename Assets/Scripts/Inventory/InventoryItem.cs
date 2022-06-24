using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TiposDeItem
{
    Armas,
    Pociones,
    Pergaminos,
    Ingredientes,
    Tesoros
}

[CreateAssetMenu(menuName ="Item")]

public class InventoryItem : ScriptableObject
{
    [Header("Parametros")]
    public string Id;
    public string Nombre;
    public Sprite Icono;
    [TextArea] public string Descripcion;

    [Header("Informacion")]
    public TiposDeItem Tipo;
    public bool IsConsumible;
    public bool IsAcumulable;
    public int AcumulacionMax;

    [HideInInspector] public int Cant;


    public InventoryItem CopyItem()
    {
        InventoryItem newInstance = Instantiate(this);
        return newInstance;
    }

    public virtual bool UseItem()
    {
        return true;
    }

    public virtual bool EquipItem()
    {
        return true;
    }

    public virtual bool RemoveItem()
    {
        return true;
    }

}
