using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public abstract partial class Entity<T, G> : PoolableMono, IEntity
    where T : Enum where G : Entity<T, G> 
{
    public EntityStateMachine<T, G> StateMachine { get; protected set; }

    public EntityAnimator EntityAnimatorCompo { get; private set; }

    //[Header("Stat")]
    //[SerializeField]
    //private EntityStatSO _entityStatSO;
    protected SpriteRenderer _spriteRenderer;
    private Material _material;

    public StatController EntityStatController { get; private set;}

    protected virtual void Awake()
    {
        Transform visual = transform.Find("Visual");

        EntityAnimatorCompo = visual.GetComponent<EntityAnimator>();
        _spriteRenderer = visual.GetComponent<SpriteRenderer>();
        _material = _spriteRenderer.material;
        EntityStatController = new StatController();

        //EntityStat = new BaseStat(_entityStatSO.EntityStat);
        SetStat();

        CreateStateMachine();
		MovementAwake();
		HealthAwake();
        FeedbackAwake();
        GetTakeDamageInfo(Vector2.zero);
    }

    protected virtual void OnEnable()
    {

    }

	public override void Initialize()
    {
		InitializeHealth();
		InitializeMovement();
        InitializedAttack();

        _spriteRenderer.color = Color.white;

        StateMachine.Initialize(default);
    }

    public Entity<T1, G1> GetEntity<T1, G1>()
    where T1 : Enum
    where G1 : Entity<T1, G1>
    {
        return this as G1;
    }

    protected virtual void Update()
    {
        if (IsDead)
        {
            StopImmediatetly();
            return;
        }

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
	}

    protected virtual void FadeOut()
    {
        _spriteRenderer.DOFade(0f, 0.2f)
            .OnComplete(() => PoolManager.Instance.DestroyObject(this));
    }

    protected abstract void SetStat();
    protected abstract BaseStat GetStatSO(); // 이건 실행 안 했을때 기즈모 그릴려고 있는 것.


    private const string FlashAmount = "_FlashAmount";
    public void SetFlash()
    {
        _material.SetFloat(FlashAmount, 0f);
        DOTween.To(() => _material.GetFloat(FlashAmount),
                   x => _material.SetFloat(FlashAmount, x),
                   0.1f, 0.125f)
               .OnComplete(() =>
               {
                   DOTween.To(() => _material.GetFloat(FlashAmount),
                              x => _material.SetFloat(FlashAmount, x),
                              0f, 0.125f);
               });
    }
}
