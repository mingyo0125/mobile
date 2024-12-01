using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossWarningPanel : UI_Component
{
    [SerializeField]
    private Image _warningImage;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            UpdateUI();
        }
    }

    public override void UpdateUI()
    {
        _warningImage.DOFade(0.75f, 0.3f).SetLoops(5, LoopType.Yoyo);
    }
}
