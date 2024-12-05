using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillSummonFactory : SummonItemFactory<SkillInfo>
{
    [SerializeField]
    private SkillListSO _skillListSO;

    public override List<SkillInfo> GetCanSummonItems()
    {
        SkillInfo[] summonItemInfos = new SkillInfo[_skillListSO.SkillLists.Count];
        for (int i = 0; i < _skillListSO.SkillLists.Count; i++)
        {
            summonItemInfos[i] = _skillListSO.SkillLists[i].SkillInfo;
        }

        return summonItemInfos.ToList();
    }
}
