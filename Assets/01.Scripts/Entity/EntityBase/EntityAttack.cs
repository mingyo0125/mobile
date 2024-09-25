using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Entity<T, G>
{
    public Weapon EquipWeapon { get; protected set; }

    public virtual float GetDamage() // ���Ⱑ ������(�÷��̾�) ���� ���������� ���ؼ� ������ ��ȯ
    {
        return _entityStatSO.EntityStat.Damage + (float)EquipWeapon?.WeaponStat.Damage;
    }
}
