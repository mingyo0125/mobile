using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossRushClearPanel : StageClearPanel
{
    [SerializeField]
    private TextMeshProUGUI _rewardCountText;

    public override void UpdateUI()
    {
        base.UpdateUI();

        _rewardCountText.SetText(BossRushManager.Instance.GetRewardValue().ToString());
    }

    protected override void CreateTween()
    {
        DOTween.To(() => _canvasGroup.alpha, a => _canvasGroup.alpha = a, 1, 1f);
    }
}
