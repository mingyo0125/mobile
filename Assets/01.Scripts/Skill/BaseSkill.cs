using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill
{
    protected SkillInfo _skillInfo { get; private set; }

    public abstract void Execute(Player user, Vector2 pos);

    public virtual bool CanUse()
    {
        return true;
    }

    public void SetSkillInfo(SkillInfo skillInfo)
    {
        _skillInfo = new SkillInfo(skillInfo);
    }

    protected virtual void PlayEffect(Vector3 pos)
    {
        PoolEffect poolEffect = PoolManager.Instance.CreateObject(_skillInfo.Effect.name) as PoolEffect;
        poolEffect.SetPosition(pos);
    }
}
