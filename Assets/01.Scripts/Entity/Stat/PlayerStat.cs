using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStat : BaseStat
{
    [field: SerializeField]
    public float ItemDropRate { get; private set; }

    [field: SerializeField]
    public float DropCoinValue { get; private set; }

    public PlayerStat(PlayerStat stat) : base(stat)
    {
        this.ItemDropRate = stat.ItemDropRate;
        this.DropCoinValue = stat.DropCoinValue;
    }
}
