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

    private const string blackImage = "Black_Image";

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            UpdateUI();
        }
    }

    public override void UpdateUI()
    {
        _canvasGroup.alpha = 1;

        UI_Image blackImage = UIManager.Instance.CreateUI("Black_Image", transform) as UI_Image;
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

                CoroutineUtil.CallWaitForSeconds(1.5f, () => _canvasGroup.DOFade(0.0f, 0.5f));
                _warningImage.DOFade(0.75f, 0.3f).SetLoops(5, LoopType.Yoyo);
            });
        });
    }
}
