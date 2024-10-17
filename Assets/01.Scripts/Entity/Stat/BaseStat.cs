using System;
using System.Collections.Generic;
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
    public Dictionary<StatType, StatInfo> Stats { get; private set; }

    [field: SerializeField]
    public StatInfo Speed { get; private set; }

    [field: SerializeField]
    public StatInfo MaxHP { get; private set; }

    [field: SerializeField]
    public StatInfo AttackRange { get; private set;}

    [field: SerializeField]
	public StatInfo Damage { get; private set; }

    [field: SerializeField]
    public StatInfo CriticalProbability { get; private set; }

    [field: SerializeField]
    public StatInfo CriticalDamageIncreasePercent { get; private set; }

    [field: SerializeField]
    public StatInfo ResistancePercent { get; private set; }

    public BaseStat(BaseStat stat)
    {
        this.Speed = stat.Speed;
        this.MaxHP = stat.MaxHP;
        this.AttackRange = stat.AttackRange;
        this.Damage = stat.Damage;
        this.CriticalProbability = stat.CriticalProbability;
        this.CriticalDamageIncreasePercent = stat.CriticalDamageIncreasePercent;
        this.ResistancePercent = stat.ResistancePercent;

        Stats = new Dictionary<StatType, StatInfo>()
        {
            { StatType.Speed, Speed },
            { StatType.MaxHp, MaxHP },
            { StatType.AttackRange, AttackRange },
            { StatType.Damage, Damage },
            { StatType.CriticalProbability, CriticalProbability },
            { StatType.CriticalDamageIncreasePercent, CriticalDamageIncreasePercent },
            { StatType.ResistancePercent, ResistancePercent },
        };
    }

    public void SetValue(StatType statType, float value)
    {
        if(Stats.TryGetValue(statType, out StatInfo statInfo))
        {
            statInfo.Value = value;
        }
        else
        {
            Debug.LogError($"{GetType()}'s {statType} is Not Defined");
        }
    }

    //public float GetValue(StatType statType)
    //{
    //    if (Stats.TryGetValue(statType, out StatInfo statInfo))
    //    {
    //        return statInfo.Value;
    //    }
    //    else
    //    {
    //        Debug.LogError($"{GetType()}'s {statType} is Not Defined");
    //        return 0.0f;
    //    }
    //}
}
