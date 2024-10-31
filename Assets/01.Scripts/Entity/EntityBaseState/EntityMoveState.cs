using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMoveState<T, G> : EntityState<T, G> where T : Enum where G : Entity<T, G>
{
    public EntityMoveState(G entity, EntityStateMachine<T, G> entityStateMachine):
                           base(entity, entityStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        _owner.EntityAnimatorCompo.SetFloat("Speed", _owner.Speed);
    }

    public override void ExitState()
    {
        base.ExitState();

        _owner.EntityAnimatorCompo.SetFloat("Speed", -1f);
    }

}
