
using UnityEngine;

public class SkillButtonInfo
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public float CoolTime { get; private set; }
    public Sprite Icon { get; private set; }

    public void SetInfo(SkillInfo skillInfo)
    {
        this.Name = skillInfo.SummonItemInfo.ItemId;
        this.Description = skillInfo.Description;
        this.CoolTime = skillInfo.Cooldown;

        this.Icon = skillInfo.SummonItemInfo.Icon;
    }
}
