using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="IA/Decisions/Detect Player")]
public class DecisionDetectPlayer : IADecision
{
    public override bool Decide(IAController controller)
    {
        return DetectPlayer(controller);
    }


    private bool DetectPlayer(IAController controller)
    {
        Collider2D playerDetected = Physics2D.OverlapCircle(controller.transform.position,
            controller.RangeDetection, controller.PlayerLayerMask);

        if(playerDetected != null)
        {
            controller.PlayerReference = playerDetected.transform;
            return true;
        }
        controller.PlayerReference = null;
        return false;
    }
}
