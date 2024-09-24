using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : EntityMoveState<PlayerStateType, Player>
{
    public PlayerMoveState(Player player, EntityStateMachine<PlayerStateType, Player> entityStateMachine):
                           base(player, entityStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void FixedUpdateState()
    {
    }

    public override void UpdateState()
    {
        if(_entity.GetInRange().Item1)
        {
            Debug.Log(_entity.GetInRange().Item2.Length);
        }
    }
}
