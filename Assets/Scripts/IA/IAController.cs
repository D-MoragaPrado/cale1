using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    [Header("Estados")]
    [SerializeField] private IAEstado estadoInicial;
    [SerializeField] private IAEstado estadoDefault;

    public IAEstado EstadoActual { get; set; }

    private void Start()
    {
        EstadoActual = estadoInicial;
    }

    private void Update()
    {
        EstadoActual.ExecuteEstado(this);
    }


    public void ChangeEstado(IAEstado newEstado)
    {
        if(newEstado != estadoDefault)
        {
            EstadoActual = newEstado;
        }
    }
}
