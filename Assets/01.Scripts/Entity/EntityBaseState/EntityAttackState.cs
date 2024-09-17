using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttackState<T, G> : EntityState<T, G> where T : Enum where G : Entity<T, G>
{
    public EntityAttackState(Entity<T, G> entity, EntityStateMachine<T, G> entityStateMachine) : base(entity, entityStateMachine)
    {
    }
}
