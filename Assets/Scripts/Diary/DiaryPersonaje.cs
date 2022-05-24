using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TiposDePersonaje
{
    Leyenda,
    Mito,
    Cargo,
    PersonajeInventado,
    None
}
[CreateAssetMenu(menuName = "DiaryPersonaje")]
public class DiaryPersonaje : ScriptableObject
{

    [Header("Parametros")]
    public string Id;
    public string Nombre;
    public string tipo;
    public Sprite Icono;
    [TextArea] public string Descripcion;

    [Header("Informacion")]
    public TiposDePersonaje Tipo;



}
