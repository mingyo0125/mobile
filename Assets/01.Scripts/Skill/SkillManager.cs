using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillManager : MonoSingleTon<SkillManager>
{
    [SerializeField]
    private SkillListSO _skillListSO;

    private PlayerSkillHolder _skillHolder;

    public Dictionary<string, BaseSkill> Skills { get; private set; } = new Dictionary<string, BaseSkill>();

    private SkillButtonsController _skillButtonsController;

    private void Awake()
    {
        _skillHolder = FindAnyObjectByType<PlayerSkillHolder>();
        _skillButtonsController = FindAnyObjectByType<SkillButtonsController>();

        foreach (BaseSkill skill in _skillListSO.SkillLists)
        {
            Skills.Add(skill.SkillInfo.SkillName, skill);
        }

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Skills.Values.ToList().ForEach(s => _skillButtonsController.SubscribeSkill(s));
        }
    }

    public void AddSkill(string skillId)
    {
        if(!Skills.TryGetValue(skillId, out BaseSkill skill)) { return; }

        _skillHolder.AddSkill(skillId, skill);
    }

    public void RemoveSkill(string skillId)
    {
        if (!Skills.ContainsKey(skillId)) { return; }

        _skillHolder.RemoveSkill(skillId);
    }
}
