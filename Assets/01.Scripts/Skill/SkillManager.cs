using System;
using UnityEngine;

public class SkillManager : MonoSingleTon<SkillManager>
{
    [SerializeField]
    private SkillListSO _skillListSO;

    private PlayerSkillHolder _skillHolder;


    private void Awake()
    {
        _skillHolder = FindAnyObjectByType<PlayerSkillHolder>();

        foreach (BaseSkill skill in _skillListSO.SkillLists)
        {
            _skillHolder.AddSkill(skill.SkillInfo.SkillName, skill);
        }

    }
}
