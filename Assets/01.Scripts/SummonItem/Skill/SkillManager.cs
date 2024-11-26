using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkillManager : MonoSingleTon<SkillManager>
{
    [SerializeField]
    private SkillListSO _skillListSO;

    private PlayerSkillHolder _skillHolder;

    public Dictionary<string, BaseSkill> Skills { get; private set; } = new Dictionary<string, BaseSkill>();
    public Dictionary<string, int> SkillsInventory { get; private set; } = new Dictionary<string, int>();

    private SkillButtonsController _skillButtonsController;

    private void Awake()
    {
        _skillButtonsController = FindAnyObjectByType<SkillButtonsController>();

        _skillHolder = FindAnyObjectByType<PlayerSkillHolder>();

        foreach (BaseSkill skill in _skillListSO.SkillLists)
        {
            Skills.Add(skill.SkillInfo.ItemId, skill);
            skill.InitializeSkillInfo();
        }
    }

    public void AddSkill(string skillId)
    {
        if(!Skills.TryGetValue(skillId, out BaseSkill skill)) { return; }

        if(!SkillsInventory.ContainsKey(skillId)) // ó�� ȹ�� ������
        {
            SkillsInventory.Add(skillId, 0);
        }

            // ������ �ִ� ��ų�� ���� ���Ѵ�.
        Skills[skillId].SkillInfo.AddElementsCount();
    }

    public void UnEquipSkill(string skillId)
    {
        if (!Skills.TryGetValue(skillId, out BaseSkill skill)) { return; }

        _skillHolder.RemoveSkill(skillId);

        _skillButtonsController.UnSubscribeSkill(skill);
    }

    public bool EquipSkill(string skillId)
    {
        if(!SkillsInventory.ContainsKey(skillId))
        {
            Debug.LogError($"Player doesn't have {skillId}Skill");
            return false;
        }

        if (!Skills.TryGetValue(skillId, out BaseSkill skill)) { return false; }

        if(_skillButtonsController.SubscribeSkill(skill)) // ��ų ĭ�� �� ������ �ʾƼ� �ٷ� �����ϸ�
        {
            _skillHolder.AddSkill(skillId, skill);
            return true;
        }

        Debug.Log(false);
        return false;
    }

    //public SkillInfo GetSkillInfo(string id)
    //{
    //    if(!_skillInfos.TryGetValue(id, out SkillInfo skill_Info))
    //    {
    //        Debug.LogError($"Player doesn't have {id}Skill");
    //        return null;
    //    }

    //    return skill_Info;
    //}    
}
