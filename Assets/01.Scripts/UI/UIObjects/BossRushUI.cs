using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BossRushUI : UI_Component
{
    [SerializeField]
    private TextMeshProUGUI _rewardText;

    [SerializeField]
    private Image _appearBossImage;

    [SerializeField]
    private BossRushChangeLevelButton _leftButton, _rightButton;

    [SerializeField]
    private BossRushEnterButton _enterButton;

    [SerializeField]
    private GameObject _lockPanel;

    private BossRushInfo _curBossRushInfo;

    public void UpdateBossRushUI(BossRushInfo bossRussInfo)
    {
        _curBossRushInfo = bossRussInfo;

        _rewardText.SetText(BossRushManager.Instance.GetRewardValue().ToString());

        _appearBossImage.sprite = _curBossRushInfo.ApeearBoss;

        _lockPanel.SetActive(!CanEnterLevel(_curBossRushInfo.Level));

        _leftButton.SetCurLevel(_curBossRushInfo.Level);
        _rightButton.SetCurLevel(_curBossRushInfo.Level);
    }

    public void SetButtonEvents(Action<int> changeLevelEvent)
    {
        _leftButton.OnChangeLevelEvent = changeLevelEvent;
        _rightButton.OnChangeLevelEvent = changeLevelEvent;
    }

    private bool CanEnterLevel(int level)
    {
        return WaveManager.Instance.CurStageCount > level;
    }
}
