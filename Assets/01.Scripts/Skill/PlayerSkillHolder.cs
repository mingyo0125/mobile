using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerSkillHolder : MonoBehaviour
{
    private Dictionary<string, BaseSkill> _skills = new Dictionary<string, BaseSkill>();

    private Dictionary<string, float> _lastUsedTimes = new Dictionary<string, float>();

    public void AddSkill(string id, BaseSkill skill)
    {
        _skills.Add(id, skill);
        _lastUsedTimes.Add(id, -Mathf.Infinity);  // 처음에는 쿨타임을 바로 사용할 수 있도록 설정
    }

    public void PlaySkill(string id)
    {
        if (!_skills.TryGetValue(id, out BaseSkill skill))
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
        if (Time.time < lastUsedTime + skill.SkillInfo.BaseCooldown)
        {
            // 쿨타임
            Debug.Log(lastUsedTime + skill.SkillInfo.BaseCooldown - Time.time);
            return false;
        }

        return true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlaySkill("Fireball");
        }
    }
}
