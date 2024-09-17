using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState<T, G> : EntityAttackState<T, G> where T : Enum where G : Entity<T, G>
{
    public PlayerAttackState(Entity<T, G> entity, EntityStateMachine<T, G> entityStateMachine) : base(entity, entityStateMachine)
    {
    }
}
