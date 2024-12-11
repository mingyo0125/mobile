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

    private const float DefualtAttackSpeed = 0.5f;

    private bool isAttacking;
    public bool CanAttack
    {
        get
        {
            return StateMachine.CurrentState.GetAttackable() && !isAttacking;
        }
    }

    private void InitializedAttack()
    {
        isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        if (isDrawRangeGizmo)
        {
            float attackRange = GetStatSO().AttackRange.Value;

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

    protected virtual (bool, float) GetDamage(float skillDamagePercent = 100)
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

    public TakeDamageInfo GetTakeDamageInfo(Vector2 hitPoint)
    {
        if (_entityTakeDamageInfo == null)
        {
            _entityTakeDamageInfo = new TakeDamageInfo();
        }

        UpdateTakeDamageInfo(hitPoint);
        return _entityTakeDamageInfo;
    }

    public TakeDamageInfo GetSkillDamageInfo(SkillInfo skillInfo, Vector2 hitPoint)
    {
        if (_entityTakeDamageInfo == null)
        {
            _entityTakeDamageInfo = new TakeDamageInfo();
        }

        UpdateSkillDamageInfo(skillInfo, hitPoint);
        return _entityTakeDamageInfo;
    }

    private void UpdateTakeDamageInfo(Vector2 hitPoint)
    {
        var calculateDamage = GetDamage();

        _entityTakeDamageInfo.UpdateTakeDamageInfo(calculateDamage.Item2,
                                                   calculateDamage.Item2 * 0.25f,
                                                   calculateDamage.Item1,
                                                   transform.position,
                                                   hitPoint);
    }

    private void UpdateSkillDamageInfo(SkillInfo skillInfo, Vector2 hitPoint)
    {
        var calculateDamage = GetDamage(skillInfo.DamagePercent);

        _entityTakeDamageInfo.UpdateTakeDamageInfo(calculateDamage.Item2,
                                                   calculateDamage.Item2 * 0.25f,
                                                   calculateDamage.Item1,
                                                   transform.position,
                                                   hitPoint);

        _entityTakeDamageInfo.UpdateHitFeedbackEffect(skillInfo.HitFeedbackEffect);
    }

    public float GetAttackDelay()
    {
        return DefualtAttackSpeed;
    }

    public void SetIsAttacking(bool canAttack)
    {
        this.isAttacking = canAttack;
    }
}
