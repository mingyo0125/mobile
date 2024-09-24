using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStat
{
    [field: SerializeField]
    public float Damage { get; private set; }

    public WeaponStat(WeaponStat weaponStat)
    {
        Damage = weaponStat.Damage;
    }
}
