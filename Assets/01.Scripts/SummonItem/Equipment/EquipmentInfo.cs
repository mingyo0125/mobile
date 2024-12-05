using System;
using UnityEngine;

[Serializable]
public class EquipmentInfo : SummonItemInfo
{
    [field: SerializeField]
    public float ItemValue { get; private set; }

    public EquipmentInfo(EquipmentInfo summonItemInfo) : base(summonItemInfo)
    {
        this.ItemValue = summonItemInfo.ItemValue;
    }

    public override bool EquipItem()
    {
        base.EquipItem();
        return SkillManager.Instance.EquipSummonItem(ItemId);
    }

    public override void UnEquipItem()
    {
        base.UnEquipItem();
        SkillManager.Instance.UnEquipSummonItem(ItemId);
    }

    public override void GetItem()
    {
        Debug.Log($"GetItem {ItemId}");
        SkillManager.Instance.AddSummonItem(ItemId);
        base.GetItem();
    }

    public override bool ItemLevelUp()
    {
        if (!base.ItemLevelUp()) { return false; }

        ItemValue += GradeInfo.UpgradeIncreaseValue;

        Debug.Log($"{ItemName}DamagePercent: {ItemValue}");

        return true;
    }
}
