using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Skill_IconFactory : SummonItemIconFactory
{
    [SerializeField]
    private SkillListSO _skillListSO;

    protected override List<SummonItemInfo> GetSummonItems()
    {
        SummonItemInfo[] summonItemInfos = new SummonItemInfo[_skillListSO.SkillLists.Count];
        for (int i = 0; i < _skillListSO.SkillLists.Count; i++)
        {
            summonItemInfos[i] = _skillListSO.SkillLists[i].SkillInfo.SummonItemInfo;
        }

        return summonItemInfos.ToList();
    }
}
