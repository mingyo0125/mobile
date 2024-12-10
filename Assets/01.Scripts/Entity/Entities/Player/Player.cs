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

    private Coroutine _hpRegenCoroutine;
    private WaitForSeconds _regenTime = new WaitForSeconds(1f);

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

        if (!IsDead && _hpRegenCoroutine == null)
        {
            _hpRegenCoroutine = StartCoroutine(RegenerationCorou());
        }
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

    // Àç»ý
    private IEnumerator RegenerationCorou()
    {
        while (HP < MaxHP)
        {
            float regenPercent = EntityStatController.GetStatValue(StatType.HPRegeneration);
            SetHp(Utils.CalculatePercent(MaxHP, regenPercent), Color.green);

            yield return _regenTime;
        }

        _hpRegenCoroutine = null;
    }
}
