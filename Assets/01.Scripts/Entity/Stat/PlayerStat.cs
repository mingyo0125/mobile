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
        this.ItemDropRate = stat.ItemDropRate;
        this.DropCoinValue = stat.DropCoinValue;

        Stats.Add(StatType.ItemDropRate, ItemDropRate);
        Stats.Add(StatType.DropCoinValue, DropCoinValue);

        Debug.Log("ADd");
    }
}
