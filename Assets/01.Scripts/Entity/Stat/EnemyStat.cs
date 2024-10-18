using System;
using UnityEngine;

[Serializable]
public class EnemyStat : BaseStat
{
    [field: SerializeField]
    public StatInfo AttackDelay { get; private set; }

    //[field: SerializeField]
    //public StatInfo AttackRange { get; private set; }

    public EnemyStat(EnemyStat stat) : base(stat)
    {
        this.AttackDelay = stat.AttackDelay;
        //this.AttackRange = stat.AttackRange;

        Stats.Add(StatType.AttackDelay, AttackDelay);
        //Stats.Add(StatType.AttackRange, AttackRange);
    }
}
