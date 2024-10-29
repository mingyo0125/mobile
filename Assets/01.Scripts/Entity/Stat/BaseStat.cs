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
    public StatInfo Damage { get; private set; }

    [field: SerializeField]
    public StatInfo MaxHP { get; private set; }

    [field: SerializeField]
    public StatInfo Speed { get; private set; }

    [field: SerializeField]
    public StatInfo AttackDelay { get; private set; }

    [field: SerializeField]
    public StatInfo AttackRange { get; private set;}

    [field: SerializeField]
    public StatInfo CriticalProbability { get; private set; }

    [field: SerializeField]
    public StatInfo CriticalDamageIncreasePercent { get; private set; }

    [field: SerializeField]
    public StatInfo ResistancePercent { get; private set; }

    public BaseStat(BaseStat stat)
    {
        this.Speed = new StatInfo(stat.Speed.Level, stat.Speed.Value, stat.Speed.StatUIInfo);
        this.MaxHP = new StatInfo(stat.MaxHP.Level, stat.MaxHP.Value, stat.MaxHP.StatUIInfo);
        this.AttackRange = new StatInfo(stat.AttackRange.Level, stat.AttackRange.Value, stat.AttackRange.StatUIInfo);
        this.AttackDelay = new StatInfo(stat.AttackDelay.Level, stat.AttackDelay.Value, stat.AttackDelay.StatUIInfo);
        this.Damage = new StatInfo(stat.Damage.Level, stat.Damage.Value, stat.Damage.StatUIInfo);
        this.CriticalProbability = new StatInfo(stat.CriticalProbability.Level, stat.CriticalProbability.Value, stat.CriticalProbability.StatUIInfo);
        this.CriticalDamageIncreasePercent = new StatInfo(stat.CriticalDamageIncreasePercent.Level, stat.CriticalDamageIncreasePercent.Value, stat.CriticalDamageIncreasePercent.StatUIInfo);
        this.ResistancePercent = new StatInfo(stat.ResistancePercent.Level, stat.ResistancePercent.Value, stat.ResistancePercent.StatUIInfo);

        Stats = new Dictionary<StatType, StatInfo>()
        {
            { StatType.Damage, Damage },
            { StatType.MaxHp, MaxHP },
            { StatType.Speed, Speed },
            { StatType.AttackRange, AttackRange },
            { StatType.AttackDelay, AttackDelay },
            { StatType.CriticalProbability, CriticalProbability },
            { StatType.CriticalDamageIncreasePercent, CriticalDamageIncreasePercent },
            { StatType.ResistancePercent, ResistancePercent },
        };
    }

    public void SetStatValue(StatType statType, float value)
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

    public void StatLevelUp(StatType statType)
    {
        if (Stats.TryGetValue(statType, out StatInfo statInfo))
        {
            statInfo.Level++;
        }
        else
        {
            Debug.LogError($"{GetType()}'s {statType} is Not Defined");
        }
    }
}
