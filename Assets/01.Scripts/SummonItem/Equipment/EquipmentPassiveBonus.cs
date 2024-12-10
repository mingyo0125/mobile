using System;
using UnityEngine;

[Serializable]
public class EquipmentPassiveBonus
{
    [field: SerializeField]
    public StatType IncreaseStatType { get; private set; }

    [field: SerializeField]
    public float IncreaseValue { get; private set; }

    public void UpgradeIncreaseValue(float value)
    {
        IncreaseValue += value;
    }
}
