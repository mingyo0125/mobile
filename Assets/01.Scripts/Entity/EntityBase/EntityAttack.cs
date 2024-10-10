using System.Collections;
using System.Collections.Generic;
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

    private void OnDrawGizmos()
    {
        if (isDrawRangeGizmo)
        {
            Gizmos.color = _gizmoColor;
            Gizmos.DrawWireSphere(transform.position, _entityStatSO.EntityStat.AttackRange);
        }
    }

    protected virtual (bool, float) GetDamage() // 무기가 있으면(플레이어) 무기 데미지까지 더해서 데미지 반환
    {
        float damage = EntityStat.Damage;
        bool isCritical = Utils.CalculateProbability(EntityStat.CriticalProbability);

        if (EquipWeapon != null)
        {
            damage += EquipWeapon.WeaponStat.Damage;
        }

        if (isCritical)
        {
            damage += (EntityStat.CriticalDamageIncreasePercent * 0.01f * EntityStat.Damage);
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
}
