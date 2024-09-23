using System;
using UnityEngine;

public abstract partial class Entity<T, G> : PoolableMono where T : Enum where G : Entity<T, G>
{
    public EntityStateMachine<T, G> StateMachine { get; protected set; }

    public EntityAnimator EntityAnimatorCompo { get; private set; }

    protected virtual void Awake()
    {
        CreateStateMachine();
        InitializeMoveable();

        EntityAnimatorCompo = transform.Find("Visual").GetComponent<EntityAnimator>();
    }

    public override void Initialize()
    {
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
