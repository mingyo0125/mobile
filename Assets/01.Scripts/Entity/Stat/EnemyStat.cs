using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyStat : BaseStat
{
    [field: SerializeField]
    public StatInfo AttackDelay { get; private set; }

    public EnemyStat(EnemyStat stat) : base(stat)
    {
        this.AttackDelay = stat.AttackDelay;
        Stats.Add(StatType.AttackDelay, AttackDelay);
    }
}
