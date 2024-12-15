using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWaveUI : WaveUI
{
    [SerializeField]
    private SpawnBossButton _spawnBossButton;

    private bool isButtonEnabled = false;


    protected override void Awake()
    {
        base.Awake();

        _spawnBossButton.AddClickEvent(DisableWaveUI);

        Signalhub.OnEnterBossRushEvent += DisableWaveUI;

        Signalhub.OnStageClearEvent += _ => EnableWaveUI();
        Signalhub.OnEndBossRushEventEvent += EnableWaveUI;
    }

    public override void EnableWaveUI()
    {
        base.EnableWaveUI();

        _spawnBossButton.SetInteractableButton(enemyCount == goalCount);
        isButtonEnabled = true;
    }

    public override void UpdateUI()
    {
        base.UpdateUI();

        bool enable = enemyCount == goalCount;
        if (enable != isButtonEnabled)
        {
            isButtonEnabled = enable;
            _spawnBossButton.SetInteractableButton(isButtonEnabled);
        }
    }

    protected override int SetGoalCount()
    {
        return 1;
    }
}
