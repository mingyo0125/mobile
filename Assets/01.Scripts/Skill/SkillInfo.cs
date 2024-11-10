using System;
using UnityEngine;

[Serializable]
public class SkillInfo
{
    [field: SerializeField]
    public string SkillName { get; private set; }
    [field: SerializeField]
    public string Description { get; private set; }
    [field: SerializeField]
    public float Cooldown { get; private set; }
    [field: SerializeField]
    public float DamagePercent { get; private set; }

    [field: SerializeField]
    public FeedbackEffect HitFeedbackEffect { get; private set; }

    public SkillInfo(SkillInfo skillInfo)
    {
        this.SkillName = skillInfo.SkillName;
        this.Description = skillInfo.Description;
        this.Cooldown = skillInfo.Cooldown;
        this.DamagePercent = skillInfo.DamagePercent;

    }
}