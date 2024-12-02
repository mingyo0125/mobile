using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossTimeLimitUI : UI_Component
{
    [SerializeField]
    private TextMeshProUGUI _timeLimitText;

    [SerializeField]
    private Image _timeLimitImage;

    private const float timeLimit = 35.0f;

    private Coroutine _timeLimitCoroutine = null;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public override void UpdateUI()
    {
        _canvasGroup.alpha = 1.0f;
        _timeLimitCoroutine = StartCoroutine(UpdateTimeLimitUICorou());
    }

    public void StopUpdateTimeLimitUICoroutine()
    {
        if(_timeLimitCoroutine != null)
        {
            StopCoroutine(_timeLimitCoroutine);
            _timeLimitCoroutine = null;

            _canvasGroup.alpha = 0.0f;
        }
    }

    private IEnumerator UpdateTimeLimitUICorou()
    {
        float elapsedTime = 0.0f;

        while(elapsedTime < timeLimit)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / timeLimit;

            float remainTime = timeLimit - t;

            _timeLimitText.SetText(remainTime.ToString("F2"));
            _timeLimitImage.fillAmount = 1.0f - t;

            yield return null;
        }

        _canvasGroup.alpha = 0.0f;

        _timeLimitText.SetText("0.00");
        _timeLimitImage.fillAmount = 0.0f;
    }
}
