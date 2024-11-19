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
            skill.InitializeSkillInfo();
            Skills.Add(skill.SkillInfo.SummonItemInfo.ItemName, skill);
        }

        AddSkill("Fireball");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            foreach(var skill in Skills)
            {
                AddSkill(skill.Key);
            }
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            foreach (var skill in Skills)
            {
                Debug.Log(skill.Value.SkillInfo.SummonItemInfo.ElementsCount);
            }
        }
    }

    public void AddSkill(string skillId)
    {
        if(!Skills.TryGetValue(skillId, out BaseSkill skill)) { return; }

        if (_skillHolder.CanUseSkills.ContainsKey(skillId))
        {
            _skillHolder.AddSkill(skillId, skill);
            SkillsInventory.Add(skillId, 0);
        }

        // ������ �ִ� ��ų�� ���� ���Ѵ�.
        Skills[skillId].SkillInfo.SummonItemInfo.AddElementsCount();
    }

    public void RemoveSkill(string skillId)
    {
        if (!Skills.ContainsKey(skillId)) { return; }

        _skillHolder.RemoveSkill(skillId);
    }

    public void EquipSkill(string skillId)
    {
        if (!Skills.TryGetValue(skillId, out BaseSkill skill)) { return; }

        _skillButtonsController.SubscribeSkill(skill);
    }
}
