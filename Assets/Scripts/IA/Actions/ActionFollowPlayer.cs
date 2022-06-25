using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="IA/Actions/Follow Player")]
public class ActionFollowPlayer : IAAccion
{
    public override void Execute(IAController controller)
    {
        FollowPlayer(controller);
    }

    private void FollowPlayer(IAController controller)
    {
        if (controller.PlayerReference == null)
        {
            return;
        }
        Vector3 dirToPlayer = controller.PlayerReference.position - controller.transform.position;
        Vector3 direction = dirToPlayer.normalized;
        float distance = dirToPlayer.magnitude;

        if (distance>= 50f)
        {
            controller.transform.Translate(direction * controller.SpeedMovement * Time.deltaTime);
        }
    }
}
