using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveUI : UI_Component
{
    [SerializeField]
    private SpawnBossButton _spawnBossButton;

    [SerializeField]
    private TextMeshProUGUI _enemyCountText;

    private CanvasGroup _canvasGroup;

    private int enemyCount = 0;

    private const int goalCount = 1;

    private bool isButtonEnabled = false;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        _spawnBossButton.AddClickEvent(DisableWaveUI);

        Signalhub.OnStageClearEvent += EnableWaveUI;
    }

    private void DisableWaveUI()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
    }

    public void EnableWaveUI(bool isClear)
    {
        gameObject.SetActive(true);

        if(isClear)
        {
            enemyCount = 0;
        }

        _spawnBossButton.SetInteractableButton(!isClear);
        isButtonEnabled = !isClear;

        _enemyCountText.SetText($"{enemyCount} / {goalCount}");

        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;

    }

    public override void UpdateUI()
    {
        enemyCount = Mathf.Clamp(enemyCount + 1, 0, goalCount); 

        _enemyCountText.SetText($"{enemyCount} / {goalCount}");
        
        bool enable = enemyCount == goalCount;
        if (enable != isButtonEnabled)
        {
            isButtonEnabled = enable;
            _spawnBossButton.SetInteractableButton(isButtonEnabled);
        }
    }


}
