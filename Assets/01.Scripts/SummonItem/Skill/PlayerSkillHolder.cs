using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillHolder : MonoBehaviour
{
    public Dictionary<string, BaseSkill> CanUseSkills { get; private set; } = new Dictionary<string, BaseSkill>();

    private Dictionary<string, float> _lastUsedTimes = new Dictionary<string, float>();

    private IEntity _owner;

    private void Awake()
    {
        _owner = transform.parent.GetComponent<IEntity>();
    }

    public void AddSkill(string id, BaseSkill skill)
    {
        CanUseSkills.Add(id, skill);
        Debug.Log($"Add Skill {id}");
        _lastUsedTimes.Add(id, -Mathf.Infinity);  
    }

    public void RemoveSkill(string id)
    {
        CanUseSkills.Remove(id);
        Debug.Log($"Remove Skill {id}");
        _lastUsedTimes.Remove(id);
    }

    public void PlaySkill(string id)
    {
        if (!CanUseSkills.TryGetValue(id, out BaseSkill skill))
        {
            Debug.LogError($"Player didn't Equip {id} Skill");
            return;
        }

        Player player = _owner.GetEntity<PlayerStateType, Player>() as Player;
        player.StopImmediatetly();

        // player.EntityAnimatorCompo.SetTriggerQueue("AttackTrigger",
        //                                            player
        //                                                .EntityStatController
        //                                                .GetStatValue(StatType.AttackDelay));

        player.EntityAnimatorCompo.QueueSkillAnimationTrigger(id,
                                                   player.GetAttackDelay(),
                                                   () => SpawnSkill(id, skill));
    }

    private void SpawnSkill(string id, BaseSkill skill)
    {
        BaseSkill skillInstance = PoolManager.Instance.CreateObject(id) as BaseSkill;
        skillInstance.InitializeSkillInfo(skill.SkillInfo);

        _lastUsedTimes[id] = Time.time;
        skillInstance.Execute(GameManager.Instance.GetPlayer(), (Vector2)transform.position + skillInstance.SpawnDir);

        Player player = _owner.GetEntity<PlayerStateType, Player>() as Player;
        player.SetMove();
    }
}
