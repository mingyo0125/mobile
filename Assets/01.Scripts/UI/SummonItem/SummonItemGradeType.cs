
using System;
using UnityEngine;

public enum SummonItemGradeType
{
    Common = 100,
    Rare = 25,
    Epic = 10,
    Unique = 3,
    Legendary = 1
}

[Serializable]
public struct ItemGradeInfo
{
    [field: SerializeField]
    public SummonItemGradeType ItemGradeType { get; private set; }

    [field: SerializeField]
    public Color ColorByGrade { get; private set; }

    [field: SerializeField]
    public float Upgrade_Equipped_IncreaseValue { get; private set; }

    [field: SerializeField]
    public float Upgrade_Passive_IncreaseValue { get; private set; }
}
