using System;
using UnityEngine;

[Serializable]
public class EquipmentInfo : SummonItemInfo
{
    [field: SerializeField]
    public float ItemValue { get; private set; }

    [field: SerializeField]
    public EquipmentPassiveBonus EquipmentPassiveBonus { get; private set; }

    public EquipmentInfo(EquipmentInfo summonItemInfo) : base(summonItemInfo)
    {
        this.ItemValue = summonItemInfo.ItemValue;

        this.EquipmentPassiveBonus = summonItemInfo.EquipmentPassiveBonus;
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
        if (IsLock) // 처음에 획득하면 보유 효과
        {
            GameManager.Instance.GetPlayer()
                .EntityStatController
                .IncreaseStat(EquipmentPassiveBonus.IncreaseStatType, EquipmentPassiveBonus.IncreaseValue);
        }

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
        GameManager.Instance.GetPlayer()
                .EntityStatController
                .DecreaseStat(EquipmentPassiveBonus.IncreaseStatType, EquipmentPassiveBonus.IncreaseValue);

        EquipmentPassiveBonus.UpgradeIncreaseValue(GradeInfo.Upgrade_Passive_IncreaseValue);

        GameManager.Instance.GetPlayer()
                .EntityStatController
                .IncreaseStat(EquipmentPassiveBonus.IncreaseStatType, EquipmentPassiveBonus.IncreaseValue);


        if (isEquipped)
        {
            GameManager.Instance.GetPlayer().EntityStatController.DecreaseStat(StatType.Damage, ItemValue);
            ItemValue += GradeInfo.Upgrade_Equipped_IncreaseValue;
            GameManager.Instance.GetPlayer().EntityStatController.IncreaseStat(StatType.Damage, ItemValue);
        }
        else
        {
            ItemValue += GradeInfo.Upgrade_Equipped_IncreaseValue;
        }

        base.ItemLevelUpEvent();
    }
}
