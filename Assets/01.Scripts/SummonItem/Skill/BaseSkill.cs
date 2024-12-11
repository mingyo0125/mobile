using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : PoolableMono
{
    [SerializeField]
    public SkillInfoSO SkillInfoSO;

    [SerializeField]
    [Range(0f, 5f)]
    protected float castRadius;

    public SkillInfo SkillInfo { get; private set; }

    protected SkillVisual _viusal;

    [field: SerializeField]
    public Vector2 SpawnDir { get; private set; }

    [SerializeField]
    protected LayerMask _enemyLayer;

    [SerializeField]
    private bool isCollisionUpdate, shouldDisappearOnCollision, useAnimationEvent;

    protected virtual void Awake()
    {
        _viusal = transform.Find("Visual").GetComponent<SkillVisual>();

        _viusal.OnAnimationEndEvent += () => PoolManager.Instance.DestroyObject(this);

        if(useAnimationEvent)
        {
            _viusal.OnTakeDamageEvent += TakeDamage;
        }
    }

    public void InitializeSkillInfo(SkillInfo sharedSkillInfo)
    {
        SkillInfo = sharedSkillInfo;
    }

    public override void Initialize()
    {
        base.Initialize();
        _viusal.Initialize();
    }

    private void Update()
    {
        if (!isCollisionUpdate) { return; }

        if(TakeDamage() && shouldDisappearOnCollision)
        {
            _viusal.StopImmediately();
            _viusal.AnimationEndEvent();
        }
    }

    public virtual void Execute(Player user, Vector2 pos)
    {
        PlayEffect(pos);
    }

    protected virtual void PlayEffect(Vector3 pos)
    {
        _viusal.transform.position = pos;
    }

    protected virtual bool TakeDamage()
    {
        bool isHit = false;

        RaycastHit2D[] hits = Physics2D.CircleCastAll(_viusal.transform.position, castRadius, _viusal.transform.position, 0, _enemyLayer);
        foreach (RaycastHit2D hit in hits)
        {
            bool isEnemy = hit.collider.TryGetComponent(out IDamageable damageable) && damageable is Enemy;
            if (!isEnemy) { return false; }

            Vector2 hitPoint = hit.point;

            damageable.TakedDamage(GameManager.Instance.GetPlayer().GetSkillDamageInfo(SkillInfo, hitPoint));

            isHit = true;
        }

        return isHit;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, castRadius);
    }
}
