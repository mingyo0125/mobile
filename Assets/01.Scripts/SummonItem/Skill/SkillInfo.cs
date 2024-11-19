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

    //public SkillInfo(SkillInfo skillInfo)
    //{
    //    this.Description = skillInfo.Description;
    //    this.Cooldown = skillInfo.Cooldown;
    //    this.DamagePercent = skillInfo.DamagePercent;
    //}

    public override bool EquipItem()
    {
        return SkillManager.Instance.EquipSkill(ItemId);
    }

    public override void UnEquipItem()
    {
        SkillManager.Instance.UnEquipSkill(ItemId);
    }

    public override void GetItem()
    {
        base.GetItem();
        Debug.Log($"GetItem {ItemId}");
        SkillManager.Instance.AddSkill(ItemId);
    }
}