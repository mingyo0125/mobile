using System;
using UnityEngine;

public abstract partial class Entity<T, G> : PoolableMono where T : Enum where G : Entity<T, G>
{
    public EntityStateMachine<T, G> StateMachine { get; protected set; }

    public EntityAnimator EntityAnimatorCompo { get; private set; }

    [Header("Stat")]
    [SerializeField]
    private EntityStatSO _entityStatSO;

    public Stat EntityStat { get; private set; }

    protected virtual void Awake()
    {
        CreateStateMachine();
        InitializeMovement();
        InitializeHealth();
        InitializeRangeCheckable();

        EntityAnimatorCompo = transform.Find("Visual").GetComponent<EntityAnimator>();
        EntityStat = _entityStatSO.EntityStat;
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
