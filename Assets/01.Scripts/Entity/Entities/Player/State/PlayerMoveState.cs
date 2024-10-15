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
		bool isInRange = GetInRange(100f).Item1;

        Debug.Log("A");

        if (isInRange)
        {
            Vector2 shortestPos = GetShortestTargetPos(GetInRange(100f).Item2); // 있기만 하면 어디에 있던 쫓아감

            Debug.Log(shortestPos);
            _owner.SetTargetTrm(shortestPos);
            _owner.Move(shortestPos);
        }
    }

    public override void UpdateState()
    {
        if (GetAttackable())
        {
            _stateMachine.ChangeState(PlayerStateType.Attack);
        }
    }

	public override void ExitState()
	{
		base.ExitState();

        _owner.EntityAnimatorCompo.SetFloat("Speed", -1f);
	}
}
