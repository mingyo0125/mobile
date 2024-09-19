using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EntityState<T, G> where T : Enum where G : Entity<T, G>
{
    protected G _entity;
    protected EntityStateMachine<T, G> _entityStateMachine;

    private string stateName;

    public EntityState(G entity, EntityStateMachine<T, G> entityStateMachine)
    {
        _entity = entity;
        _entityStateMachine = entityStateMachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void UpdateState() { }
    public virtual void FixedUpdateState() { }

    public virtual void AnimationTriggerEvent(AnimationTriggerType animationTriggerType) { }
}
