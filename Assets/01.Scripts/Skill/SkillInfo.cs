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
    public float BaseCooldown { get; private set; }
    [field: SerializeField]
    public float BaseDamagePercent { get; private set; }

    public SkillInfo(SkillInfo skillInfo)
    {
        this.SkillName = skillInfo.SkillName;
        this.Description = skillInfo.Description;
        this.BaseCooldown = skillInfo.BaseCooldown;
        this.BaseDamagePercent = skillInfo.BaseDamagePercent;

    }
}