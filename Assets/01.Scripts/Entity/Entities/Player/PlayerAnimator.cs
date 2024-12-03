using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : EntityAnimator
{
    protected override void EndAttack()
    {
        base.EndAttack();

        _owner.GetEntity<PlayerStateType, Player>().StateMachine.ChangeState(PlayerStateType.Idle);
    }
}
