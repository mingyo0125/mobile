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

    public TakeDamageInfo EntityTakeDamageInfo { get; private set; }

    private void OnDrawGizmos()
    {
        if (isDrawRangeGizmo)
        {
            Gizmos.color = _gizmoColor;
            Gizmos.DrawWireSphere(transform.position, _entityStatSO.EntityStat.AttackRange);
        }
    }

    protected virtual (bool, float) GetDamage() // ���Ⱑ ������(�÷��̾�) ���� ���������� ���ؼ� ������ ��ȯ
    {
        float entityDamage = EntityStat.Damage;
        bool isCritical = CustomRandom.CalculateProbability(EntityStat.CriticalProbability);

        if(isCritical)
        {
            entityDamage += (EntityStat.CriticalDamageIncreasePercent * 0.01f * EntityStat.Damage);
        }


        float totalDamage = entityDamage + EquipWeapon?.WeaponStat.Damage ?? 0f;
        return (isCritical, totalDamage);
    }

    public void UpadteTakeDamageInfo()
    {
        var calculateDamage = GetDamage();

        if (EntityTakeDamageInfo == null)
        {
            EntityTakeDamageInfo = new TakeDamageInfo(calculateDamage.Item2,
                                                 calculateDamage.Item2 * 0.1f,
                                                 calculateDamage.Item1,
                                                 transform.position);
        }
        else
        {
            EntityTakeDamageInfo.UpdateTakeDamageInfo(calculateDamage.Item2, calculateDamage.Item1, transform.position);
        }

        EquipWeapon?.SetTakeDamageInfo(EntityTakeDamageInfo);
    }
}
