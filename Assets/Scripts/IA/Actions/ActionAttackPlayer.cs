using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "IA/Actions/Attack Player")]
public class ActionAttackPlayer : IAAccion
{
    public override void Execute(IAController controller)
    {
        Attack(controller);
    }

    private void Attack(IAController controller)
    {
        if (controller.PlayerReference == null)
        {
            return;
        }

        if (controller.IsTimeAttack() == false)
        {
            return;
        }

        if (controller.PlayerInRangeAttack(controller.RangeAttackDetermined))
        {
            if (controller.TypeAttack == AttackTypes.Embestida)
            {
                controller.AttackRamming(controller.Damage);
            }
            else
            {
                controller.AttackMelee(controller.Damage);
            }
            
            controller.UpdateTimeBetweenAtack();
        }
    }
}
