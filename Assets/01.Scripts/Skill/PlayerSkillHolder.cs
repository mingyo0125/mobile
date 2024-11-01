using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillHolder : MonoBehaviour
{
    private Dictionary<string, BaseSkill> _skills = new Dictionary<string, BaseSkill>();

    public void AddSkill(string id, BaseSkill skill)
    {
        _skills.Add(id, skill);
    }

    public void PlayerSkill(string id)
    {
        if (!_skills.TryGetValue(id, out BaseSkill skill))
        {
            Debug.LogError($"Player doesn't have {id} Skill");
            return;
        }

        if(!skill.CanUse())
        {
            return;
        }

        //skill.Execute();
    }
}
