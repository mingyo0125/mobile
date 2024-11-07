using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillHolder : MonoBehaviour
{
    public Dictionary<string, BaseSkill> Skills { get; private set; } = new Dictionary<string, BaseSkill>();


    private Dictionary<string, float> _lastUsedTimes = new Dictionary<string, float>();

    public void AddSkill(string id, BaseSkill skill)
    {
        Skills.Add(id, skill);
        _lastUsedTimes.Add(id, -Mathf.Infinity);  
    }

    public void PlaySkill(string id)
    {
        if (!Skills.TryGetValue(id, out BaseSkill skill))
        {
            Debug.LogError($"Player doesn't have {id} Skill");
            return;
        }

        if(!CanUse(id, skill))
        {
            return;
        }
        
        BaseSkill skillInstance = PoolManager.Instance.CreateObject(id) as BaseSkill;


        _lastUsedTimes[id] = Time.time;
        skillInstance.Execute(GameManager.Instance.GetPlayer(), transform.position);
    }

    private bool CanUse(string id, BaseSkill skill)
    {
        float lastUsedTime = _lastUsedTimes[id];
        if (Time.time < lastUsedTime + skill.SkillInfo.Cooldown)
        {
            // ÄðÅ¸ÀÓ
            Debug.Log(lastUsedTime + skill.SkillInfo.Cooldown - Time.time);
            return false;
        }

        return true;
    }
}
