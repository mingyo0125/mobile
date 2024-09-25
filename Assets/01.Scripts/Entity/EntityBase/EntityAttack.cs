using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Entity<T, G>
{
    public Weapon EquipWeapon { get; protected set; }

    protected virtual float GetDamage()
    {
        return _entityStatSO.EntityStat.Damage + (float)EquipWeapon?.WeaponStat.Damage;
    }
}
