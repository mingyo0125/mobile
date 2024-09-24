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
        _entity.Move(new Vector2(100, 100));
    }
}
