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
        _owner.Move(Vector2.right);
    }

}
