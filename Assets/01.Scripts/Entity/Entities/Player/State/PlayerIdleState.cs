using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : EntityIdleState<PlayerStateType, Player>
{
    public PlayerIdleState(Player player, EntityStateMachine<PlayerStateType, Player> stateMachine):
                           base(player, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        _entityStateMachine.ChangeState(PlayerStateType.Move);
    }
}
