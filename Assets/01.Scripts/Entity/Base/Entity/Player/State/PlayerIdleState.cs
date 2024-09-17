using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState<T, G> : EntityIdleState<T, G> where T : Enum where G : Entity<T, G>
{
    public PlayerIdleState(Entity<T, G> entity, EntityStateMachine<T, G> entityStateMachine) : base(entity, entityStateMachine)
    {
    }
}
