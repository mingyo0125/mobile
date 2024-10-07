using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EntityIdleState<EnemyStateType, Enemy>
{
    public EnemyIdleState(Enemy enemy, EntityStateMachine<EnemyStateType, Enemy> entityStateMachine):
                          base(enemy, entityStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        _stateMachine.ChangeState(EnemyStateType.Move);
    }
}
