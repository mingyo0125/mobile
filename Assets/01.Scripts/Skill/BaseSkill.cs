using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill
{
    protected SkillInfo _skillInfo { get; private set; }

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
