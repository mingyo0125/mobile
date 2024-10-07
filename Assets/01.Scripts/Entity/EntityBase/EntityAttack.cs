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

    private void OnDrawGizmos()
    {
        if (isDrawRangeGizmo)
        {
            Gizmos.color = _gizmoColor;
            Gizmos.DrawWireSphere(transform.position, _entityStatSO.EntityStat.AttackRange);
        }
    }

    public virtual float GetDamage() // ���Ⱑ ������(�÷��̾�) ���� ���������� ���ؼ� ������ ��ȯ
    {
        float entityDamage = EntityStat.Damage;
        bool isCritical = CustomRandom.CalculateProbability(EntityStat.CriticalProbability);

        if(isCritical)
        {
            entityDamage += (EntityStat.CriticalDamageIncreasePercent * 0.01f * EntityStat.Damage);
        }

        float totalDamage = entityDamage + EquipWeapon?.WeaponStat.Damage ?? 0f;
        return totalDamage;
    }
}
