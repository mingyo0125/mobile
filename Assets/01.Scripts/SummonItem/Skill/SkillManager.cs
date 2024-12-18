using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillManager : SummonItemManager<SkillInfo>
{
    [SerializeField]
    private SkillListSO _skillListSO;

    private Dictionary<string, BaseSkill> _skills = new Dictionary<string, BaseSkill>();

    private PlayerSkillHolder _skillHolder;
    private SkillButtonsController _skillButtonsController;

    private List<SkillInfo> _skillInfos = new List<SkillInfo>();

    protected override void Awake()
    {
        _skillButtonsController = FindAnyObjectByType<SkillButtonsController>();
        _skillHolder = FindAnyObjectByType<PlayerSkillHolder>();

        foreach (BaseSkill skill in _skillListSO.SkillLists)
        {
            SkillInfo skillInfo = DataManager.Instance.LoadData<SkillInfo, SummonItemData<SkillInfo>>(skill.SkillInfoSO.SkillInfo).ItemInfo;
            _skills.Add(skillInfo.ItemId, skill);
            _skillInfos.Add(skillInfo);
            skill.InitializeSkillInfo(skillInfo);
        }

        base.Awake();
    }

    public override void UnEquipSummonItem(string skillId)
    {
        base.UnEquipSummonItem(skillId);

        _skillHolder.RemoveSkill(skillId);

        BaseSkill skill = GetSkill(skillId);

        _skillButtonsController.UnSubscribeSkill(skill);
    }

    public override bool EquipSummonItem(string skillId)
    {
        base.EquipSummonItem(skillId);

        BaseSkill skill = GetSkill(skillId);

        if (_skillButtonsController.SubscribeSkill(skill)) // 스킬 칸이 다 차있지 않아서 바로 가능하면
        {
            _skillHolder.AddSkill(skillId, skill);
            return true;
        }

        return false;
    }

    public override List<SkillInfo> GetSummonItems()
    {
        return _skillInfos;
    }

    public BaseSkill GetSkill(string skillId)
    {
        if (!_skills.TryGetValue(skillId, out BaseSkill skill))
        {
            Debug.LogError($"{skillId}Skill is not found");
        }

        return skill;
    }
}
