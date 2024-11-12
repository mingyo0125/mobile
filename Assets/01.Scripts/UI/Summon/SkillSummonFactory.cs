using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSummonFactory : SummonItemFactory<SkillInfo>
{
    [SerializeField]
    private SkillListSO _skillListSO; // ��ų ����Ʈ So�� �ٲټ�

    private List<SkillInfo> _skillInfoList = new List<SkillInfo>();

    private void Start()
    {
        foreach (BaseSkill item in _skillListSO.SkillLists)
        {
            _skillInfoList.Add(item.SkillInfo);
        }

        SpawnSummonItem(30);
    }

    public override List<SkillInfo> GetCanSummonItems()
    {
        return _skillInfoList;
    }
}
