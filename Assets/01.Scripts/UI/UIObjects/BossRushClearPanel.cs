using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRushClearPanel : StageClearPanel
{
    protected override void CreateTween()
    {
        DOTween.To(() => _canvasGroup.alpha, a => _canvasGroup.alpha = a, 1, 1f);
    }
}
