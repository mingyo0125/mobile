using System;
using UnityEngine;

[Serializable]
public class SkillInfo : SummonItemInfo
{
    [TextArea]
    [SerializeField]
    public string Description;

    [field: SerializeField]
    public float Cooldown { get; private set; }
    [field: SerializeField]
    public float DamagePercent { get; private set; }

    [field: SerializeField]
    public float SpawnCount { get; private set; } = 1;

    [field: SerializeField]
    public FeedbackEffect HitFeedbackEffect { get; private set; }

    public SkillInfo(SkillInfo skillInfo) : base(skillInfo)
    {
        this.Description = skillInfo.Description;
        this.Cooldown = skillInfo.Cooldown;
        this.DamagePercent = skillInfo.DamagePercent;
        this.SpawnCount = skillInfo.SpawnCount;

        this.HitFeedbackEffect = skillInfo.HitFeedbackEffect;
    }

    public override bool ItemLevelUp()
    {
        if (!base.ItemLevelUp()) { return false; }

        Debug.Log($"{ItemName}DamagePercent: {DamagePercent}");

        return true;
    }

    protected override void ItemLevelUpEvent()
    {
        DamagePercent += GradeInfo.Upgrade_Equipped_IncreaseValue;
        base.ItemLevelUpEvent();
    }

    protected override string GetFilePath()
    {
        return $"Skills/{ItemId} SkillData.json";
    }
}