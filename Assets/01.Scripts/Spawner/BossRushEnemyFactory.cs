using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRushEnemyFactory : EnemyFactory
{
    private int curLevel;

    protected BossRushWaveUI _bossRushWaveUI;

    protected override void Awake()
    {
        base.Awake();

        _bossRushWaveUI = FindAnyObjectByType<BossRushWaveUI>();
    }


    public void SetEnter(int level)
    {
        curLevel = level;
    }

    protected override void SubscribeEnemyDieEvent(Enemy enemy)
    {
        enemy.OnDieEvent += _ => _bossRushWaveUI.UpdateUI();
        enemy.OnDieEvent += _ =>  WaveManager.Instance.IncreaseBossRushDeadEnemyCount();
    }

    protected override Enemy GetEnemy()
    {
        if (_spawnEntitys.Length < curLevel)
        {
            Debug.LogError($"{name} doesn't have {curLevel} Stage Enemy");
            return null;
        }

        return _spawnEntitys[curLevel - 1];
    }
}
