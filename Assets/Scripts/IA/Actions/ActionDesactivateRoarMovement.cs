using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "IA/Actions/Desactivate Road Movement")]
public class ActionDesactivateRoarMovement : IAAccion
{
    public override void Execute(IAController controller)
    {
        if (controller.EnemyMovement == null)
        {
            return;
        }

        controller.EnemyMovement.enabled = false;
    }
}
