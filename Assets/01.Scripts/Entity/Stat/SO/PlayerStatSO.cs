using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stat/PlayerStat")]
public class PlayerStatSO : ScriptableObject
{
    [field: SerializeField]
    public PlayerStat PlayerStat { get; private set; }
}
