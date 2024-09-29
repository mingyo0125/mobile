using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMoveState : EntityMoveState<PlayerStateType, Player>
{
    public PlayerMoveState(Player player, EntityStateMachine<PlayerStateType, Player> entityStateMachine):
                           base(player, entityStateMachine)
    {
    }

    public override void FixedUpdateState()
    {
		bool isInRange = _entity.GetInRange(100f).Item1;

        if (isInRange)
        {
            Vector2 shortestPos = _entity.GetShortestTargetPos(_entity.GetInRange(100f).Item2); // 있기만 하면 어디에 있던 쫓아감

            _entity.SetTargetTrm(shortestPos);
            _entity.Move(shortestPos);
        }
    }

    public override void UpdateState()
    {
        bool isInRange = _entity.GetInRange(_entity.CheckRangeDistance).Item1;
        if (isInRange)
        {
            _entityStateMachine.ChangeState(PlayerStateType.Attack);
        }
    }

	public override void ExitState()
	{
		base.ExitState();

        _entity.EntityAnimatorCompo.SetFloat("Speed", -1f);
	}
}
