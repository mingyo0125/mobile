using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossRushUI : UI_Component
{
    [SerializeField]
    private TextMeshProUGUI _rewardText;

    [SerializeField]
    private Image _appearBossImage;

    [SerializeField]
    private UI_Button _leftButton, _rightButton;

    [SerializeField]
    private UI_Button _enterButton;

    [SerializeField]
    private Image _lockPanel;

    private BossRushInfo _curBossRushInfo;

    public void UpdateBossRushUI(BossRushInfo bossRussInfo)
    {
        _curBossRushInfo = bossRussInfo;

        _rewardText.SetText(GetRewardCount(_curBossRushInfo.Level).ToString());

        _appearBossImage.sprite = _curBossRushInfo.ApeearBoss;

        _lockPanel.enabled = CanEnterLevel(_curBossRushInfo.Level);
    }

    private int GetRewardCount(int level)
    {
        return 500 + (level - 1) * 10;
    }

    private bool CanEnterLevel(int level)
    {
        return WaveManager.Instance.CurStageCount >= level;
    }
}
