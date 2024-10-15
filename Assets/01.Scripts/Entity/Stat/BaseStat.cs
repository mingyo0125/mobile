using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
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
public struct StatPair
{
    public int Level { get; private set; }
    public float Value { get; private set; }

    public StatPair(int level, float value)
    {
        this.Level = level;
        this.Value = value;
    }

    public void SetValue(float value)
    {
        Value = value;
    }
}

[Serializable]
public class BaseStat
{
    [field: SerializeField]
    public StatPair Speed { get; private set; }

    [field: SerializeField]
    public StatPair MaxHP { get; private set; }

    [field: SerializeField]
    public StatPair AttackRange { get; private set;}

    [field: SerializeField]
    public StatPair AttackDelay { get; private set; }

    [field: SerializeField]
	public StatPair Damage { get; private set; }

    [field: SerializeField]
    public StatPair CriticalProbability { get; private set; }

    [field: SerializeField]
    public StatPair CriticalDamageIncreasePercent { get; private set; }

    [field: SerializeField]
    public StatPair ResistancePercent { get; private set; }

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
