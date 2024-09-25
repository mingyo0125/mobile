using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Entity<T, G>
{
    public Weapon EquipWeapon { get; protected set; }

    public virtual float GetDamage() // 무기가 있으면(플레이어) 무기 데미지까지 더해서 데미지 반환
    {
        return _entityStatSO.EntityStat.Damage + (float)EquipWeapon?.WeaponStat.Damage;
    }
}
