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

        if(_entity.GetInRange(100f).Item1)
        {
			_entityStateMachine.ChangeState(PlayerStateType.Move);
		}
	}
}
