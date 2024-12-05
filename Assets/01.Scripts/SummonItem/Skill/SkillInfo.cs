using System;
using UnityEngine;

[Serializable]
public class SkillInfo : SummonItemInfo
{
    [field: SerializeField]
    public string Description { get; private set; }
    [field: SerializeField]
    public float Cooldown { get; private set; }
    [field: SerializeField]
    public float DamagePercent { get; private set; }

    [field: SerializeField]
    public FeedbackEffect HitFeedbackEffect { get; private set; }

    //[field: SerializeField]
    //public SummonItemInfo SummonItemInfo;

    public SkillInfo(SkillInfo skillInfo) : base(skillInfo)
    {
        this.Description = skillInfo.Description;
        this.Cooldown = skillInfo.Cooldown;
        this.DamagePercent = skillInfo.DamagePercent;
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

        DamagePercent += GradeInfo.UpgradeIncreaseValue;

        Debug.Log($"{ItemName}DamagePercent: {DamagePercent}");

        return true;
    }
}