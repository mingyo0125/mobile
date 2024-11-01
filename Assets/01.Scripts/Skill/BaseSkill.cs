using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill
{
    private SkillInfo _skillInfo;

    public abstract void Execute(Player user);

    public virtual bool CanUse()
    {
        return true;
    }

    public void SetSkillInfo(SkillInfo skillInfo)
    {
        _skillInfo = new SkillInfo(skillInfo);
    }
}
