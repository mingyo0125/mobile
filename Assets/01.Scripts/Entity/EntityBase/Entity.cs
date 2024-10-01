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

    public Vector2 TargetPos { get; private set; }

    protected virtual void Awake()
    {
        EntityAnimatorCompo = transform.Find("Visual").GetComponent<EntityAnimator>();
        EntityStat = _entityStatSO.EntityStat;

		CreateStateMachine();
		MovementAwake();
		HealthAwake();
		RangeCheckableAwake();
        FeedbackAwake();

    }

	public override void Initialize()
    {
		InitializeHealth();
		InitializeMovement();

		StateMachine.Initialize(default);
	}

    public void SetTargetTrm(Vector3 targetPos)
    {
        TargetPos = targetPos;
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

	private void OnDisable()
	{
		HealthDisable();
        MovemetDisable();
	}
}
