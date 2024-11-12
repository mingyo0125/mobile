using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : PoolableMono
{
    [SerializeField]
    protected SkillInfoSO _skillInfoSO;

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
    private bool isCollisionUpdate, shouldDisappearOnCollision;

    protected virtual void Awake()
    {
        _viusal = transform.Find("Visual").GetComponent<SkillVisual>();

        _viusal.OnAnimationEndEvent += () => PoolManager.Instance.DestroyObject(this);

        InitializeSkillInfo();
    }

    public void InitializeSkillInfo()
    {
        SkillInfo = new SkillInfo(_skillInfoSO.SkillInfo);
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
        RaycastHit2D hit = Physics2D.CircleCast(_viusal.transform.position, castRadius, _viusal.transform.position, 0, _enemyLayer);
        if (hit)
        {
            bool isEnemy = hit.collider.TryGetComponent(out IDamageable damageable) && damageable is Enemy;
            if (!isEnemy) { return false; }

            Vector2 hitPoint = hit.point;

            damageable.TakedDamage(GameManager.Instance.GetPlayer().GetSkillDamageInfo(SkillInfo, hitPoint));

            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, castRadius);
    }
}
