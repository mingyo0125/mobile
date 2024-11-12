using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonButton : UIButton
{
    [SerializeField]
    private int summonCount;

    [SerializeField]
    private Transform _spawnParentTrm;

    private SkillSummonFactory _skillSummonFactory;

    protected override void Awake()
    {
        base.Awake();

        _skillSummonFactory = FindAnyObjectByType<SkillSummonFactory>();
    }

    protected override void ButtonEvent()
    {
        base.ButtonEvent();
        _skillSummonFactory.SpawnSummonItem(_spawnParentTrm, summonCount);
    }
}
