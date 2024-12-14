using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWaveUI : WaveUI
{
    [SerializeField]
    private SpawnBossButton _spawnBossButton;

    private bool isButtonEnabled = false;

    private CanvasGroup _canvasGroup;

    protected override void Awake()
    {
        base.Awake();
        _canvasGroup = GetComponent<CanvasGroup>();

        _spawnBossButton.AddClickEvent(DisableWaveUI);

        Signalhub.OnBossRushEnterEvent += DisableWaveUI;
    }

    private void DisableWaveUI()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
    }

    public override void EnableWaveUI(bool isClear)
    {
        base.EnableWaveUI(isClear);

        _spawnBossButton.SetInteractableButton(false);
        isButtonEnabled = false;

        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;

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
}
