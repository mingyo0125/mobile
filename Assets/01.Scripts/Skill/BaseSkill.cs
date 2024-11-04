using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : PoolableMono
{
    [SerializeField]
    protected SkillInfoSO _skillInfoSO;

    public SkillInfo SkillInfo => _skillInfoSO.SkillInfo;

    private PoolEffect _effect;

    private void Awake()
    {
        _effect = GetComponent<PoolEffect>();

        _effect.OnDestoryEvent += () => PoolManager.Instance.DestroyObject(this);
    }

    public override void Initialize()
    {
        base.Initialize();
        _effect.Initialize();
    }

    public abstract void Execute(Player user, Vector2 pos);

    public virtual bool CanUse()
    {
        return true;
    }

    protected virtual void PlayEffect(Vector3 pos)
    {
        _effect.transform.position = pos;
    }
}
