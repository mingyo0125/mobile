using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class WaveUI : UI_Component
{
    [SerializeField]
    private TextMeshProUGUI _enemyCountText;

    private CanvasGroup _canvasGroup;

    protected int enemyCount = 0;

    protected int goalCount = 1;

    protected virtual void Awake()
    {
        goalCount = SetGoalCount();

        _canvasGroup = GetComponent<CanvasGroup>();

        Signalhub.OnStageClearEvent += ResetEnemyCount;
    }

    protected void DisableWaveUI()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
    }

    public virtual void EnableWaveUI()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;

        _enemyCountText.SetText($"{enemyCount} / {goalCount}");
    }

    private void ResetEnemyCount(bool isClear)
    {
        enemyCount = 0;

        _enemyCountText.SetText($"{enemyCount} / {goalCount}");
    }

    public override void UpdateUI()
    {
        enemyCount = Mathf.Clamp(enemyCount + 1, 0, goalCount);

        _enemyCountText.SetText($"{enemyCount} / {goalCount}");
    }

    protected abstract int SetGoalCount();

}
