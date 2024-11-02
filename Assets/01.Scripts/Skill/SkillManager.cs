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

        foreach (SkillInfo skillInfoSo in _skillListSO.SkillList)
        {
            SkillInfo skillInfo = new SkillInfo(skillInfoSo);
            Type skillType = Type.GetType(skillInfo.SkillName);

            BaseSkill skill = Activator.CreateInstance(skillType) as BaseSkill;

            skill.SetSkillInfo(skillInfo);
            _skillHolder.AddSkill(skillInfo.SkillName, skill);
        }

    }
}
