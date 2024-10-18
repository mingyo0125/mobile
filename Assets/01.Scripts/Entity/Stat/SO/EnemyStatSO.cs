using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stat/EnemyStat")]
public class EnemyStatSO : EntityStatSO
{
    [field: SerializeField]
    public EnemyStat EnemyStat { get; private set; }

    [field: SerializeField]
    public StatInfo AttackRange { get; private set; }
}
