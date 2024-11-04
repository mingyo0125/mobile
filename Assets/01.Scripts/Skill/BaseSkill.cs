using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : PoolableMono
{
    [SerializeField]
    protected SkillInfoSO _skillInfoSO;

    public SkillInfo SkillInfo => _skillInfoSO.SkillInfo;

    private SkillVisual _effect;

    protected virtual void Awake()
    {
        _effect = GetComponent<SkillVisual>();

        _effect.OnAnimationEndEvent += () => PoolManager.Instance.DestroyObject(this);
    }

    public override void Initialize()
    {
        base.Initialize();
        _effect.Initialize();
    }

    public abstract void Execute(Player user, Vector2 pos);

    protected virtual void PlayEffect(Vector3 pos)
    {
        _effect.transform.position = pos;
    }
}
