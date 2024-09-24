using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStat
{
    public float Damage { get; set; }

    public WeaponStat(WeaponStat weaponStat)
    {
        Damage = weaponStat.Damage;
    }
}
