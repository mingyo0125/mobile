using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatController
{
    protected Dictionary<StatType, StatPair> _stats = new Dictionary<StatType, StatPair>();

    public BaseStat EntityStat { get; private set; }

    public void Initialize(BaseStat stat)
    {
        EntityStat = stat;
        SetStat(EntityStat, 1);
    }

    protected virtual void SetStat(BaseStat stat, int level) // 일단 1로 하는데 나중에 구조체던 뭐던 한번에 저장해서 하는 식으로
    {
        _stats.Add(StatType.Speed, new StatPair(level, stat.Speed.Value));
        _stats.Add(StatType.MaxHp, new StatPair(level, stat.MaxHP.Value));
        _stats.Add(StatType.AttackRange, new StatPair(level, stat.AttackRange.Value));
        _stats.Add(StatType.AttackDelay, new StatPair(level, stat.AttackDelay.Value));
        _stats.Add(StatType.Damage, new StatPair(level, stat.Damage.Value));
        _stats.Add(StatType.CriticalProbability, new StatPair(level, stat.CriticalProbability.Value));
        _stats.Add(StatType.CriticalDamageIncreasePercent, new StatPair(level, stat.CriticalDamageIncreasePercent.Value));
        _stats.Add(StatType.ResistancePercent, new StatPair(level, stat.ResistancePercent.Value));
    }

    public float GetStatValue(StatType statType)
    {
        if (_stats.TryGetValue(statType, out StatPair stat))
        {
            return stat.Value;
        }
        else
        {
            Debug.LogError($"{statType} is not defined");

            return 0f;
        }
    }

    public int GetStatLevel(StatType statType)
    {
        if (_stats.TryGetValue(statType, out StatPair stat))
        {
            return stat.Level;
        }
        else
        {
            Debug.LogError($"{statType} is not defined");

            return 0;
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
        _stats[statType].SetValue(value);
    }

    public StatUpgradeUIInfo GetStatUpgradeUIInfo(StatType statType)
    {
        return new StatUpgradeUIInfo(GetStatLevel(statType),
                                     statType.ToString(),
                                     GetStatValue(statType),
                                     10 * GetStatLevel(statType));
        // cost는 나중에 수학 그걸로
    }
}
