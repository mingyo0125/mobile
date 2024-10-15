using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatController : StatController
{
    protected override void SetStat(BaseStat stat)
    {
        base.SetStat(stat);

        PlayerStat playerStat = stat as PlayerStat;

        _stats.Add(StatType.ItemDropRate, playerStat.ItemDropRate);
        _stats.Add(StatType.DropCoinValue, playerStat.DropCoinValue);
    }
}
