using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_IconFactory : SummonItemIconFactory<SkillInfo>
{
    [SerializeField]
    private SkillListSO _skillListSO;

    private List<SkillInfo> _skillInfoList = new List<SkillInfo>();

    protected override void Awake()
    {
        foreach (BaseSkill item in _skillListSO.SkillLists)
        {
            _skillInfoList.Add(item.SkillInfo);
        }
    }

    protected override List<SkillInfo> GetSummonItems()
    {
        return _skillInfoList;
    }
}
