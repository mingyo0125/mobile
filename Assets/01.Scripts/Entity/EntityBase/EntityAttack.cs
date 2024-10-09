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

    private TakeDamageInfo _takeDamageInfo;

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
        float entityDamage = EntityStat.Damage;
        bool isCritical = CustomRandom.CalculateProbability(EntityStat.CriticalProbability);

        if(isCritical)
        {
            entityDamage += (EntityStat.CriticalDamageIncreasePercent * 0.01f * EntityStat.Damage);
        }


        float totalDamage = entityDamage + EquipWeapon?.WeaponStat.Damage ?? 0f;
        return (isCritical, totalDamage);
    }

    public TakeDamageInfo GetTakeDamageInfo()
    {
        var calculateDamage = GetDamage();

        if (_takeDamageInfo == null)
        {
            _takeDamageInfo = new TakeDamageInfo(calculateDamage.Item2,
                                                 calculateDamage.Item2 * 0.1f,
                                                 calculateDamage.Item1,
                                                 transform.position);
        }
        else
        {
            _takeDamageInfo.UpdateTakeDamageInfo(calculateDamage.Item2, calculateDamage.Item1, transform.position);
        }

        return _takeDamageInfo;
    }
}
