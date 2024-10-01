using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity<EnemyStateType, Enemy>
{
    private HudText _hudText;

    protected override void Awake()
    {
        base.Awake();

        _hudText = transform.Find("HudText").GetComponent<HudText>();

        OnTaKeDamagedEvent += _hudText.SpawnHudText;
    }

    protected override void CreateStateMachine()
    {
        StateMachine = new EnemyStateMachine(this);
    }
}
