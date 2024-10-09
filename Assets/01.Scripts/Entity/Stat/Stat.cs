using System;
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
    public float AttackDelay { get; private set; }

    [field: SerializeField]
	public float Damage { get; private set; }

    [field: SerializeField]
    public float CriticalProbability { get; private set; }

    [field: SerializeField]
    public float CriticalDamageIncreasePercent { get; private set; }


    public Stat(Stat stat)
    {
        this.Speed = stat.Speed;
        this.MaxHP = stat.MaxHP;
        this.AttackRange = stat.AttackRange;
        this.AttackDelay = stat.AttackDelay;
        this.Damage = stat.Damage;
        this.CriticalProbability = stat.CriticalProbability;
        this.CriticalDamageIncreasePercent = stat.CriticalDamageIncreasePercent;
    }

}
