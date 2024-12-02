using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossWarningPanel : UI_Component
{
    [SerializeField]
    private Image _warningImage;

    private CanvasGroup _canvasGroup;

    private const string blackImageName = "Black_Image";

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public override void UpdateUI()
    {
        _canvasGroup.alpha = 1;

        UI_Image blackImage = UIManager.Instance.CreateUI(blackImageName, transform) as UI_Image;
        blackImage.Icon.color = Color.black;
        CoroutineUtil.CallWaitForSeconds(0.2f, () =>
        {
            blackImage.Icon.DOFade(0.0f, 0.5f)
            .OnComplete(() =>
            {
                PoolManager.Instance.DestroyObject(blackImage);

                Color color = _warningImage.color;
                color.a = 0.35f;
                _warningImage.color = color;

                _warningImage.DOFade(0.75f, 0.3f).SetLoops(5, LoopType.Yoyo);

                CoroutineUtil.CallWaitForSeconds(1.5f, () => _canvasGroup.DOFade(0.0f, 0.5f).OnComplete(() =>
                {
                    PoolManager.Instance.DestroyObject(this);
                }));
            });
        });
    }
}
