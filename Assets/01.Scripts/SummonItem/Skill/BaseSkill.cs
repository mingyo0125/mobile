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

    [SerializeField]
    [Range(-5f, 5f)]
    protected float castPosX, castPosY;

    public SkillInfo SkillInfo { get; private set; }

    protected SkillVisual _viusal;

    [field: SerializeField]
    public Vector2 SpawnDir { get; private set; }

    [SerializeField]
    protected LayerMask _enemyLayer;

    [SerializeField]
    private bool isCollisionUpdate, shouldDisappearOnCollision, useAnimationEvent;

    private bool isEnd = false;

    [Header("BoxCast")]
    [SerializeField]
    private bool isBoxCast;
    [SerializeField]
    [Range(0f, 5f)]
    protected float boxCastXValue, boxCastYValue;

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
        isEnd = false;
    }

    private void Update()
    {
        if (!isCollisionUpdate || isEnd) { return; }

        if(TakeDamage() && shouldDisappearOnCollision)
        {
            isEnd = true;
            _viusal.StopImmediately();
            _viusal.PlayEndAnimation();
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
        Vector2 castPos = (Vector2)_viusal.transform.position + new Vector2(castPosX, castPosY);
        RaycastHit2D[] hits = null;

        if(isBoxCast)
        {
            hits = Physics2D.BoxCastAll(castPos, new Vector2(boxCastXValue, boxCastYValue), 0, _viusal.transform.position, _enemyLayer);
        }
        else
        {
            hits = Physics2D.CircleCastAll(castPos, castRadius, _viusal.transform.position, 0, _enemyLayer);
        }

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
        Vector2 castPos = (Vector2)transform.position + new Vector2(castPosX, castPosY);

        if (isBoxCast)
        {
            Gizmos.DrawWireCube(castPos, new Vector2(boxCastXValue, boxCastYValue));
        }
        else
        {
            Gizmos.DrawWireSphere(castPos, castRadius);
        }
    }
}
