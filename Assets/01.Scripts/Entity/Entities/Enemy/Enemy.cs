using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity<EnemyStateType, Enemy>
{
    protected override void Awake()
    {
        base.Awake();

        OnTakeDamagedEvent += SpawnHudText;
    }

    private void SpawnHudText(float damageValue)
    {
        HudText _hudText = PoolManager.Instance.CreateObject("HudText") as HudText;
        _hudText.transform.SetParent(transform);
        _hudText.SetPosition(transform.position + new Vector3(0, 0.1f, 0));
        _hudText.SpawnHudText(damageValue);
    }

    protected override void CreateStateMachine()
    {
        StateMachine = new EnemyStateMachine(this);
    }
}
