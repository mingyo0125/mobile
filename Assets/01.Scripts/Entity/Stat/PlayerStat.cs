using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStat : BaseStat, ISavable
{
    [field: SerializeField]
    public StatInfo ItemDropRate { get; private set; }

    [field: SerializeField]
    public StatInfo DropCoinValue { get; private set; }

    public string FilePath => "PlayerData.json";

    public PlayerStat(PlayerStat stat) : base(stat, true)
    {
        this.ItemDropRate = new StatInfo(stat.ItemDropRate.Level, stat.ItemDropRate.Value, stat.ItemDropRate.StatUIInfo);
        this.DropCoinValue = new StatInfo(stat.DropCoinValue.Level, stat.DropCoinValue.Value, stat.DropCoinValue.StatUIInfo);

        // PlayerStat에서 명시적으로 호출
        InitializeStats();
    }

    protected override void InitializeOwnStats()
    {
        base.InitializeOwnStats();

        Stats.Add(StatType.ItemDropRate, ItemDropRate);
        Stats.Add(StatType.DropCoinValue, DropCoinValue);
    }
}
