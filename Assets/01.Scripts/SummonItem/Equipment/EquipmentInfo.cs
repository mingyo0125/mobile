using System;
using UnityEngine;

[Serializable]
public class EquipmentInfo : SummonItemInfo
{
    [field: SerializeField]
    public float ItemValue { get; private set; }

    public EquipmentInfo(EquipmentInfo summonItemInfo) : base(summonItemInfo)
    {
        Debug.Log(this.IsLock);
        Debug.Log("B");
        this.ItemValue = summonItemInfo.ItemValue;
    }

    public override bool EquipItem()
    {
        base.EquipItem();
        return EquipmentManager.Instance.EquipSummonItem(ItemId);
    }

    public override void UnEquipItem()
    {
        base.UnEquipItem();
        EquipmentManager.Instance.UnEquipSummonItem(ItemId);
    }

    public override void GetItem()
    {
        Debug.Log($"GetItem {ItemId}");
        EquipmentManager.Instance.AddSummonItem(ItemId);
        base.GetItem();
    }

    public override bool ItemLevelUp()
    {
        if (!base.ItemLevelUp()) { return false; }

        Debug.Log($"{ItemName}DamagePercent: {ItemValue}");

        return true;
    }

    protected override void ItemLevelUpEvent()
    {
        ItemValue += GradeInfo.UpgradeIncreaseValue;
        base.ItemLevelUpEvent();
    }
}
