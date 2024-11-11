using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSummonFactory : SummonItemFactory<SkillInfo>
{
    [SerializeField]
    private List<SkillInfoSO> _skillinfoList;

    private void Start()
    {
        SpawnSummonItem(5);
    }

    public override List<SkillInfo> GetCanSummonItems()
    {
        List<SkillInfo> skills = new List<SkillInfo>();

        foreach (SkillInfoSO item in _skillinfoList) // Test
        {
            skills.Add(item.SkillInfo);
        }
        return skills;
    }
}
