using System;
using UnityEngine;

[Serializable]
public struct BossRushInfo
{
    [field: SerializeField]
    public Sprite ApeearBoss { get; private set; }

    [field: SerializeField]
    public int Level { get; private set; }
}
