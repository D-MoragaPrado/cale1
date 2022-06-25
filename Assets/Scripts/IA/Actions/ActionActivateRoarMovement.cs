using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "IA/Actions/Activate Road Movement")]
public class ActionActivateRoarMovement : IAAccion
{
    public override void Execute(IAController controller)
    {
        if (controller.EnemyMovement == null)
        {
            return;
        }

        controller.EnemyMovement.enabled = true;
    }
}
