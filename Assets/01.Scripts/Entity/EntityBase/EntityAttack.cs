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

    public Weapon EquipWeapon { get; protected set; }

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

    protected virtual (bool, float) GetDamage() // 무기가 있으면(플레이어) 무기 데미지까지 더해서 데미지 반환
    {
        float damage = EntityStatController.GetStatValue(StatType.Damage);
        bool isCritical = Utils.CalculateProbability(EntityStatController.GetStatValue(StatType.CriticalProbability));

        if (isCritical)
        {
            damage += EntityStatController.GetStatValue(StatType.CriticalDamageIncreasePercent) * 0.01f * damage;
        }

        return (isCritical, damage);
    }

    public TakeDamageInfo GetTakeDamageInfo()
    {
        if (_entityTakeDamageInfo == null)
        {
            _entityTakeDamageInfo = new TakeDamageInfo();
        }

        UpdateTakeDamageInfo();
        EquipWeapon?.SetTakeDamageInfo(_entityTakeDamageInfo);
        return _entityTakeDamageInfo;
    }

    public void UpdateTakeDamageInfo()
    {
        var calculateDamage = GetDamage();
        // 크리티컬이면 뭔가 뭔가
        _entityTakeDamageInfo.UpdateTakeDamageInfo(calculateDamage.Item2,
                                                   calculateDamage.Item2 * 0.25f,
                                                   calculateDamage.Item1,
                                                   transform.position);
    }

    public float GetAttackDelay()
    {
        return DefualtAttackDelay - EntityStatController.GetStatValue(StatType.AttackDelay);
    }
}
