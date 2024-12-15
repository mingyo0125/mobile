using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRushEnemyFactory : EnemyFactory
{
    protected BossRushWaveUI _bossRushWaveUI;

    protected override void Awake()
    {
        base.Awake();

        _bossRushWaveUI = FindAnyObjectByType<BossRushWaveUI>();
    }


    protected override void SubscribeEnemyDieEvent(Enemy enemy)
    {
        enemy.OnDieEvent += _ => _bossRushWaveUI.UpdateUI();
        enemy.OnDieEvent += _ =>  BossRushManager.Instance.IncreaseBossRushDeadEnemyCount();
    }

    protected override Enemy GetEnemy()
    {
        int level = BossRushManager.Instance.GetCurLevel();
        if (_spawnEntitys.Length < level)
        {
            Debug.LogError($"{name} doesn't have {level} Stage Enemy");
            return null;
        }

        return _spawnEntitys[level - 1];
    }
}
