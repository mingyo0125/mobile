using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncompleteCurrencyPanel : UI_Component
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public override void Initialize()
    {
        base.Initialize();
        
        _canvasGroup.alpha = 0;

        DOTween.To(() => _canvasGroup.alpha, a => _canvasGroup.alpha = a, 1, 0.5f).SetLoops(2, LoopType.Yoyo)
            .OnComplete(() =>
            {
                PoolManager.Instance.DestroyObject(this);
            });
    }
}
