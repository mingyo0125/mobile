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

    public SkillInfo SkillInfo => _skillInfoSO.SkillInfo;

    protected SkillVisual _viusal;

    [field: SerializeField]
    public Vector2 SpawnDir { get; private set; }

    [SerializeField]
    protected LayerMask _enemyLayer;

    [SerializeField]
    private bool isCollisionUpdate;

    protected virtual void Awake()
    {
        _viusal = GetComponent<SkillVisual>();

        _viusal.OnAnimationEndEvent += () => PoolManager.Instance.DestroyObject(this);
    }

    public override void Initialize()
    {
        base.Initialize();
        _viusal.Initialize();
    }

    private void Update()
    {
        if (!isCollisionUpdate) { return; }

        TakeDamage();
    }

    public abstract void Execute(Player user, Vector2 pos);

    protected virtual void PlayEffect(Vector3 pos)
    {
        _viusal.transform.position = pos;
    }

    protected virtual void TakeDamage()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, castRadius, transform.position, 0, _enemyLayer);
        if (hit)
        {
            bool isEnemy = hit.collider.TryGetComponent(out IDamageable damageable) && damageable is Enemy;
            if (!isEnemy) { return; }

            Vector2 hitPoint = hit.point;

            damageable.TakedDamage(GameManager.Instance.GetPlayer().GetSkillDamageInfo(_skillInfoSO.SkillInfo, hitPoint));

            _viusal.StopImmediately();
            _viusal.AnimationEndEvent();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, castRadius);
    }
}
