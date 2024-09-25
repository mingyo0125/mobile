using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : EntityAttackState<PlayerStateType, Player>
{
    public PlayerAttackState(Player player, EntityStateMachine<PlayerStateType, Player> entityStateMachine):
                             base(player, entityStateMachine)
    {

    }

	public override void EnterState()
	{
		Debug.Log("Attack");
		Debug.Log(_entity.EquipWeapon);
		Debug.Log(_entity);
        _entity.EquipWeapon?.Attack();
	}

	public override void UpdateState()
	{
		base.UpdateState();
	}
}
