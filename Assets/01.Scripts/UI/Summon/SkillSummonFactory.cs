using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSummonFactory : SummonItemFactory<SkillInfo>
{
    [SerializeField]
    private SkillListSO _skillListSO;

    private List<SkillInfo> _skillInfoList = new List<SkillInfo>();

    private void Start()
    {
        foreach (BaseSkill item in _skillListSO.SkillLists)
        {
            _skillInfoList.Add(item.SkillInfo);
        }
    }

    public override List<SkillInfo> GetCanSummonItems()
    {
        return _skillInfoList;
    }
}
