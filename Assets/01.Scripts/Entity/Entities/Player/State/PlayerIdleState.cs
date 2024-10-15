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

    public override void UpdateState()
	{
		base.UpdateState();
        if(GetInRange(100f).Item1)
        {
			_stateMachine.ChangeState(PlayerStateType.Move);
		}
	}
}
