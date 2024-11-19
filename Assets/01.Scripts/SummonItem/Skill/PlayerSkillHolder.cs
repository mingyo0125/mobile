using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillHolder : MonoBehaviour
{
    public Dictionary<string, BaseSkill> CanUseSkills { get; private set; } = new Dictionary<string, BaseSkill>();

    private Dictionary<string, float> _lastUsedTimes = new Dictionary<string, float>();

    public void AddSkill(string id, BaseSkill skill)
    {
        Debug.Log($"Add Skill {id}");
        CanUseSkills.Add(id, skill);
        _lastUsedTimes.Add(id, -Mathf.Infinity);  
    }

    public void RemoveSkill(string id)
    {
        CanUseSkills.Remove(id);
    }

    public void PlaySkill(string id)
    {
        if (!CanUseSkills.TryGetValue(id, out BaseSkill skill))
        {
            Debug.LogError($"Player doesn't Equip {id} Skill");
            return;
        }
        
        BaseSkill skillInstance = PoolManager.Instance.CreateObject(id) as BaseSkill;

        _lastUsedTimes[id] = Time.time;
        skillInstance.Execute(GameManager.Instance.GetPlayer(), (Vector2)transform.position + skillInstance.SpawnDir);
    }  
}
