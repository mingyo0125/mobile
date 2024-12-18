using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Skill_IconFactory : SummonItemIconFactory<SkillInfo>
{
    protected override List<SkillInfo> GetSummonItems()
    {
        var equipmentManager = SummonItemManager<SkillInfo>.Instance as SkillManager;
        return equipmentManager.GetSummonItems();
    }
}
