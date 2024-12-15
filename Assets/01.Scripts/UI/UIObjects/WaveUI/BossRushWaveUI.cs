using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRushWaveUI : WaveUI
{
    protected override void Awake()
    {
        base.Awake();

        Signalhub.OnEnterBossRushEvent += EnableWaveUI;
    }

    protected override int SetGoalCount()
    {
        return 10;
    }
}
