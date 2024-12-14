using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Dungeon/BossRushInfo")]
public class BossRushInfoSO : ScriptableObject
{
    [field: SerializeField]
    public BossRushInfo BossRushInfo { get; private set; }
}
