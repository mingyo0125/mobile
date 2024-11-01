using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStat : BaseStat
{
    [field: SerializeField]
    public StatInfo ItemDropRate { get; private set; }

    [field: SerializeField]
    public StatInfo DropCoinValue { get; private set; }

    public PlayerStat(PlayerStat stat) : base(stat)
    {
        this.ItemDropRate = new StatInfo(stat.ItemDropRate.Level, stat.ItemDropRate.Value, stat.ItemDropRate.StatUIInfo);
        this.DropCoinValue = new StatInfo(stat.DropCoinValue.Level, stat.DropCoinValue.Value, stat.DropCoinValue.StatUIInfo);

        Stats.Add(StatType.ItemDropRate, ItemDropRate);
        Stats.Add(StatType.DropCoinValue, DropCoinValue);
    }
}
