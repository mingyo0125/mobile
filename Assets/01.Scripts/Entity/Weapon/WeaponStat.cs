using System;
using UnityEngine;

[Serializable]
public class WeaponStat
{
    [field: SerializeField]
    public float Damage { get; private set; }

    [field: SerializeField]
    public float AttackDelay { get; private set; }

    public WeaponStat(WeaponStat weaponStat)
    {
        Damage = weaponStat.Damage;
        AttackDelay = weaponStat.AttackDelay;
    }
}
