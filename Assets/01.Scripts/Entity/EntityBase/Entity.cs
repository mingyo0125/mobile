using System;
using UnityEngine;

public abstract partial class Entity<T, G> : PoolableMono, IEntityHandler
    where T : Enum where G : Entity<T, G> 
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
        EntityStat = new Stat(_entityStatSO.EntityStat);

		CreateStateMachine();
		MovementAwake();
		HealthAwake();
        FeedbackAwake();
        UpadteTakeDamageInfo();
    }

    protected virtual void OnEnable()
    {

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

    public Entity<T1, G1> GetEntity<T1, G1>()
    where T1 : Enum
    where G1 : Entity<T1, G1>
    {
        return this as G1;
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

	protected virtual void OnDisable()
	{
		HealthDisable();
        MovemetDisable();
	}
}
