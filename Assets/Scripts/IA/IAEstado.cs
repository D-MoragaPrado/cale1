using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="IA/Estado")]
public class IAEstado : ScriptableObject
{
    public IAAccion[] Acciones;
    public IATransicion[] Transiciones;


    public void ExecuteEstado(IAController controller)
    {
        ExecuteAcciones(controller);
        RealizeTransiciones(controller);
    }


    private void ExecuteAcciones(IAController controller)
    {
        if (Acciones == null || Acciones.Length <=0) return;
        
        for (int i = 0; i < Acciones.Length; i++)
        {
            Acciones[i].Execute(controller);
        }
    }


    private void RealizeTransiciones(IAController controller)
    {
        if (Transiciones == null || Transiciones.Length <= 0)
        {
            return;
        }

        for (int i = 0; i < Transiciones.Length; i++)
        {
            bool decisionValor = Transiciones[i].Decision.Decide(controller);
            if (decisionValor)
            {
                controller.ChangeEstado(Transiciones[i].EstadoTrue);
            }
            else
            {
                controller.ChangeEstado(Transiciones[i].EstadoFalse);
            }
        }

    }
}
