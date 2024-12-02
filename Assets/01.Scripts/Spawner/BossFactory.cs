using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFactory : EnemyFactory
{
    protected override void SubscribeEnemyDieEvent(Enemy enemy)
    {
        base.SubscribeEnemyDieEvent(enemy);

        enemy.OnDieEvent += _ => _waveUI.EnableWaveUI();
        enemy.OnDieEvent += _ => WaveManager.Instance.StageClear();
    }
}
