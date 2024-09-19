using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public abstract partial class Entity<T, G> : PoolableMono where T : Enum where G : Entity<T, G>
{
    public EntityStateMachine<T, G> StateMachine { get; protected set; }

    protected virtual void Awake()
    {
        CreateStateMachine();
        InitializeMoveable();

        StateMachine.Initialize(default);
    }

    private void Update()
    {
        StateMachine.CurrentState?.UpdateState();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState?.FixedUpdateState();
    }

    protected abstract void CreateStateMachine();
}
