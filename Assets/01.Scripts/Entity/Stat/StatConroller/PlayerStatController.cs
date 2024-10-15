using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatController : StatController
{
    protected override void SetStat(BaseStat stat, int level)
    {
        base.SetStat(stat, level);

        PlayerStat playerStat = stat as PlayerStat;

        _stats.Add(StatType.ItemDropRate, new StatPair(level, playerStat.ItemDropRate.Value));
        _stats.Add(StatType.DropCoinValue, new StatPair(level, playerStat.DropCoinValue.Value));
    }
}
