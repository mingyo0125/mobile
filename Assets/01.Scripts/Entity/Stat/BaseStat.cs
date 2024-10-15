using System;
using UnityEngine;

public enum StatType
{
    Speed,
    MaxHp,
    AttackRange,
    AttackDelay,
    Damage,
    CriticalProbability,
    CriticalDamageIncreasePercent,
    ResistancePercent,


    #region Player

    ItemDropRate,
    DropCoinValue,

    #endregion
}

[Serializable]
public class BaseStat
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

    [field: SerializeField]
    public float ResistancePercent { get; private set; }

    public BaseStat(BaseStat stat)
    {
        this.Speed = stat.Speed;
        this.MaxHP = stat.MaxHP;
        this.AttackRange = stat.AttackRange;
        this.AttackDelay = stat.AttackDelay;
        this.Damage = stat.Damage;
        this.CriticalProbability = stat.CriticalProbability;
        this.CriticalDamageIncreasePercent = stat.CriticalDamageIncreasePercent;
        this.ResistancePercent = stat.ResistancePercent;
    }
}
