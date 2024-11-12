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
        _skillHolder = FindAnyObjectByType<PlayerSkillHolder>();
        _skillButtonsController = FindAnyObjectByType<SkillButtonsController>();

        foreach (BaseSkill skill in _skillListSO.SkillLists)
        {
            skill.SetInfo();
            Skills.Add(skill.SkillInfo.SkillName, skill);
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
                _skillButtonsController.SubscribeSkill(skill.Value);
            }
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            foreach (var skill in Skills)
            {
                Debug.Log(skill.Value.SkillInfo.ElementsCount);
            }
        }
    }

    public void AddSkill(string skillId)
    {
        if(!Skills.TryGetValue(skillId, out BaseSkill skill)) { return; }

        if(!_skillHolder.CanUseSkills.ContainsKey(skillId))
        {
            _skillHolder.AddSkill(skillId, skill);
            SkillsInventory.Add(skillId, 0);
        }

        // 가지고 있는 스킬의 수를 더한다.
        Skills[skillId].SkillInfo.AddElementsCount();
    }

    public void RemoveSkill(string skillId)
    {
        if (!Skills.ContainsKey(skillId)) { return; }

        _skillHolder.RemoveSkill(skillId);
    }
}
