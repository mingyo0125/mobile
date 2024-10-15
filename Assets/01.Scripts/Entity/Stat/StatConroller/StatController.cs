using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatController
{
    protected Dictionary<StatType, float> _stats = new Dictionary<StatType, float>();

    public BaseStat EntityStat { get; private set; }

    public void Initialize(BaseStat stat)
    {
        EntityStat = stat;
        SetStat(EntityStat);
    }

    protected virtual void SetStat(BaseStat stat)
    {
        _stats.Add(StatType.Speed, stat.Speed);
        _stats.Add(StatType.MaxHp, stat.MaxHP);
        _stats.Add(StatType.AttackRange, stat.AttackRange);
        _stats.Add(StatType.AttackDelay, stat.AttackDelay);
        _stats.Add(StatType.Damage, stat.Damage);
        _stats.Add(StatType.CriticalProbability, stat.CriticalProbability);
        _stats.Add(StatType.CriticalDamageIncreasePercent, stat.CriticalDamageIncreasePercent);
        _stats.Add(StatType.ResistancePercent, stat.ResistancePercent);
    }

    public float GetStatValue(StatType statType)
    {
        if (_stats.TryGetValue(statType, out float value))
        {
            return value;
        }
        else
        {
            Debug.LogError($"{statType} is not defined");

            return 0f;
        }
    }

    public void IncreaseStat(StatType statType, float increaseValue)
    {
        //float value = GetStatValue(statType) + Utils.CalculatePercent(GetStatValue(statType), increasePercent);
        float value = GetStatValue(statType) + increaseValue;
        UpdateStatValue(statType, value);
    }

    public void DecreaseStat(StatType statType, float decreasePercent)
    {
        //float value = GetStatValue(statType) - Utils.CalculatePercent(GetStatValue(statType), decreasePercent);
        float value = GetStatValue(statType) - decreasePercent;
        UpdateStatValue(statType, value);
    }

    public void UpdateStatValue(StatType statType, float value)
    {
        _stats[statType] = value;
    }
}
