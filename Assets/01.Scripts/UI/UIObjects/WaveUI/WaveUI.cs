using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveUI : UI_Component
{
    [SerializeField]
    private TextMeshProUGUI _enemyCountText;

    protected int enemyCount = 0;

    protected const int goalCount = 1;

    protected virtual void Awake()
    {
        Signalhub.OnStageClearEvent += EnableWaveUI;
    }

    public virtual void EnableWaveUI(bool isClear)
    {
        gameObject.SetActive(true);

        enemyCount = 0;

        _enemyCountText.SetText($"{enemyCount} / {goalCount}");
    }

    public override void UpdateUI()
    {
        enemyCount = Mathf.Clamp(enemyCount + 1, 0, goalCount); 

        _enemyCountText.SetText($"{enemyCount} / {goalCount}");
    }
}
