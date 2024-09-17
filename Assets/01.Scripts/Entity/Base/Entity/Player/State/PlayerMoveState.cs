using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState<T, G> : EntityMoveState<T, G> where T : Enum where G : Entity<T, G>
{
    public PlayerMoveState(Entity<T, G> entity, EntityStateMachine<T, G> entityStateMachine) : base(entity, entityStateMachine)
    {
    }
}
