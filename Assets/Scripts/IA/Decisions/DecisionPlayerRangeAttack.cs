using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "IA/Decisions/Player In Range Attack")]
public class DecisionPlayerRangeAttack : IADecision
{
    public override bool Decide(IAController controller)
    {
        return InRangeAttack(controller);
    }

    private bool InRangeAttack(IAController controller)
    {
        if (controller.PlayerReference == null)
        {
            return false;
        }

        float distance = (controller.PlayerReference.position - controller.transform.position).sqrMagnitude;

        if (distance < Mathf.Pow(controller.RangeAttack, 2))
        {
            return true;
        }
        return false;
    }
}
