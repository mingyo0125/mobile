using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController
{
    public BaseStat EntityStat { get; private set; }

    public void Initialize<T>(T stat) where T : BaseStat
    {
        EntityStat = Activator.CreateInstance(typeof(T), stat) as T;
    }

    public float GetStatValue(StatType statType)
    {
        if (EntityStat.Stats.TryGetValue(statType, out StatInfo stat))
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
        if (EntityStat.Stats.TryGetValue(statType, out StatInfo stat))
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
        EntityStat.SetValue(statType, value);
    }

    public StatUpgradeUIInfo GetStatUpgradeUIInfo(StatType statType)
    {
        int statLevel = GetStatLevel(statType);
        return new StatUpgradeUIInfo(statLevel,
                                     statType.ToString(),
                                     GetStatValue(statType),
                                     10 * statLevel);
        // cost는 나중에 수학 그걸로
    }
}
