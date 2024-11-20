
using UnityEngine;

public class SkillButtonInfo
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public float CoolTime { get; private set; }
    public Sprite Icon { get; private set; }

    public void SetInfo(SkillInfo skillInfo)
    {
        this.Name = skillInfo.ItemId;
        this.Description = skillInfo.Description;
        this.CoolTime = skillInfo.Cooldown;

        this.Icon = skillInfo.Icon;
    }

    public void ResetInfo()
    {
        this.Name = null;
        this.Description = null;
        this.CoolTime = 0.0f;

        this.Icon = null;
    }
}
