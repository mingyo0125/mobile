using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    [field: SerializeField]
    public float Speed { get; private set; }

    [field: SerializeField]
    public float MaxHP { get; private set; }

    [field: SerializeField]
    public float AttackRange { get; private set;}

	[field: SerializeField]
	public float Damage { get; private set; }

    public Stat(Stat stat)
    {
        this.Speed = stat.Speed;
        this.MaxHP = stat.MaxHP;
        this.AttackRange = stat.AttackRange;
        this.Damage = stat.Damage;
    }

}
