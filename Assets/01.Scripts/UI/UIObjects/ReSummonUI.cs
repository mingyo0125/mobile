using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSummonUI : UIComponent
{
    [SerializeField]
    private Transform _spawnParentTrm;

    private SkillSummonFactory _skillSummonFactory;

    public override void UpdateUI()
    {
    }

    protected virtual void Awake()
    {
        _skillSummonFactory = FindAnyObjectByType<SkillSummonFactory>();
    }

    public void SpawnSummonItem(int summonCount)
    {
        _skillSummonFactory.SpawnSummonItem(_spawnParentTrm, summonCount);
    }
}
