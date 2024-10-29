using System;
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
            Debug.LogError($"{EntityStat.GetType()}'s {statType} is not defined");

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

    public void StatLevelUp(StatType statType)
    {
        if (!EntityStat.Stats.TryGetValue(statType, out StatInfo stat))
        {
            Debug.LogError($"Entity doesn't have {statType} Stat");
            return;
        }

        EntityStat.StatLevelUp(statType);
        IncreaseStat(statType, 1);
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
        EntityStat.SetStatValue(statType, value);
    }

    public StatUpgradeUIInfo GetStatUpgradeUIInfo(StatType statType)
    {
        int statLevel = GetStatLevel(statType);
        StatUIInfo statUIInfo = EntityStat.Stats[statType].StatUIInfo;

        return new StatUpgradeUIInfo(statLevel,
                                     statUIInfo.Name,
                                     GetStatValue(statType),
                                     10 * statLevel,
                                     statUIInfo.StatSprite);
    }
}
