using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract partial class Entity<T, G>
{
    [SerializeField]
    private LayerMask _checkLayer;
    public LayerMask CheckLayer => _checkLayer;

    [Header("CheckRange")]
    [SerializeField]
    private bool isDrawRangeGizmo = false;
    public bool IsDrawRangeGizmo => isDrawRangeGizmo;

    [SerializeField]
    private Color _gizmoColor;
    public Color GizmoColor => _gizmoColor;

    private TakeDamageInfo _entityTakeDamageInfo;

    public float DefualtAttackDelay { get; private set; } = 3;

    private void OnDrawGizmos()
    {
        if (isDrawRangeGizmo)
        {
            if(this is Enemy)
            {
                EnemyStat statSO = GetStatSO() as EnemyStat;
                float attackRange = statSO.AttackRange.Value;

                try
                {
                    Gizmos.color = _gizmoColor;
                    Gizmos.DrawWireSphere(transform.position, attackRange);
                }
                catch
                {
                    Debug.LogWarning($"{gameObject} Stat is Not Setting");
                }
            }
        }
    }

    protected virtual (bool, float) GetDamage(float skillDamagePercent)
    {
        float damage = EntityStatController.GetStatValue(StatType.Damage);
        bool isCritical = Utils.CalculateProbability(EntityStatController.GetStatValue(StatType.CriticalProbability));

        if (isCritical)
        {
            damage += EntityStatController.GetStatValue(StatType.CriticalDamageIncreasePercent) * 0.01f * damage;
        }

        damage *= 0.01f * skillDamagePercent;

        return (isCritical, damage);
    }

    public TakeDamageInfo GetTakeDamageInfo()
    {
        if (_entityTakeDamageInfo == null)
        {
            _entityTakeDamageInfo = new TakeDamageInfo();
        }

        UpdateTakeDamageInfo();
        return _entityTakeDamageInfo;
    }

    public TakeDamageInfo GetSkillDamageInfo(SkillInfo skillInfo)
    {
        if (_entityTakeDamageInfo == null)
        {
            _entityTakeDamageInfo = new TakeDamageInfo();
        }

        UpdateSkillDamageInfo(skillInfo);
        return _entityTakeDamageInfo;
    }

    private void UpdateTakeDamageInfo()
    {
        var calculateDamage = GetDamage(0);

        _entityTakeDamageInfo.UpdateTakeDamageInfo(calculateDamage.Item2,
                                                   calculateDamage.Item2 * 0.25f,
                                                   calculateDamage.Item1,
                                                   transform.position);
    }

    private void UpdateSkillDamageInfo(SkillInfo skillInfo)
    {
        var calculateDamage = GetDamage(skillInfo.DamagePercent);

        _entityTakeDamageInfo.UpdateTakeDamageInfo(calculateDamage.Item2,
                                                   calculateDamage.Item2 * 0.25f,
                                                   calculateDamage.Item1,
                                                   transform.position);

        _entityTakeDamageInfo.UpdateHitFeedbackEffect(skillInfo.HitFeedbackEffect);
    }

    public float GetAttackDelay()
    {
        return DefualtAttackDelay - EntityStatController.GetStatValue(StatType.AttackDelay);
    }
}
