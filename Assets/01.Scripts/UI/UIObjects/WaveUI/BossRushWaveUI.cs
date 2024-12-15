using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRushWaveUI : WaveUI
{
    protected override void Awake()
    {
        base.Awake();

        Signalhub.OnEnterBossRushEvent += EnableWaveUI;
        Signalhub.OnEndBossRushEventEvent += DisableWaveUI;
        Signalhub.OnEndBossRushEventEvent += ResetEnemyCount;
    }

    public override void DisableWaveUI()
    {
        base.DisableWaveUI();

        enemyCount = 0;
    }

    protected override int SetGoalCount()
    {
        return 10;
    }
}
