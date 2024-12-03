using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity<PlayerStateType, Player>
{
    [Space]
    [SerializeField]
    private PlayerStatSO _playerStatSO; 

    public PlayerSkillHolder SkillHolder { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        SkillHolder = transform.Find("SkillHolder").GetComponent<PlayerSkillHolder>();
    }

    private void Start()
    {
        base.Initialize();
    }

    public override void TakedDamage(TakeDamageInfo takeDamageInfo)
    {
        base.TakedDamage(takeDamageInfo);

        StateMachine.ChangeState(PlayerStateType.Idle);
    }

    public void GetItem(Item item)
    {
        // Dosomething
    }

    protected override void CreateStateMachine()
    {
        StateMachine = new PlayerStateMachine(this);
    }

    protected override void SetStat()
    {
        PlayerStat playerStat = new PlayerStat(_playerStatSO.PlayerStat);
        EntityStatController.Initialize(playerStat);
    }

    protected sealed override BaseStat GetStatSO()
    {
        if(_playerStatSO.PlayerStat != null)
        {
            return _playerStatSO.PlayerStat;
        }
        return null;
    }

    protected override string GetHudTextValue(float value)
    {
        return value.ToString();
    }
}
