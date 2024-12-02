using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearPanel : UI_Component
{
    private const string stageClearParticle = "Flash_ellow";

    [SerializeField]
    private Transform _clearPanelTrm;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public override void UpdateUI()
    {
        _canvasGroup.alpha = 0;

        DOTween.To(() => _canvasGroup.alpha, a => _canvasGroup.alpha = a, 1, 1f).SetLoops(2, LoopType.Yoyo)
            .OnComplete(() =>
            {
                Signalhub.OnStageClearEvent?.Invoke(true);
                PoolManager.Instance.DestroyObject(this);
            });

        PoolableMono particle = PoolManager.Instance.CreateObject(stageClearParticle);
        particle.transform.SetParent(GameManager.Instance.GetPlayerTrm());
        particle.transform.localPosition = Vector2.zero;

        CoroutineUtil.CallWaitForSeconds(3f, () => PoolManager.Instance.DestroyObject(particle));
    }

}
