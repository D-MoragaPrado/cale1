using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestDescripcion : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questNombre;
    [SerializeField] private TextMeshProUGUI questDescripcion;


    public virtual void ConfQuestUI(Quest questForLoad)
    {
        questNombre.text = questForLoad.Nombre;
        questDescripcion.text = questForLoad.Descripcion;
    }
}
