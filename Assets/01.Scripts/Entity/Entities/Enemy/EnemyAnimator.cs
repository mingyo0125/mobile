using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : EntityAnimator
{
    protected override void EndAttack()
    {
        base.EndAttack();

        _owner.GetEntity<EnemyStateType, Enemy>().StateMachine.ChangeState(EnemyStateType.Move);
    }
}
