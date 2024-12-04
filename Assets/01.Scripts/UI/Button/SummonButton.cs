using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonButton : UI_Button
{
    [SerializeField]
    private ReSummonUI _reSummonUI;

    [SerializeField]
    private int summonCount;

    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        if(_reSummonUI != null)
        {
            _reSummonUI.SpawnSummonItem(summonCount);
            return;
        }

        ReSummonUI reSummonUI = UIManager.Instance.CreateUI("ReSummonUI", Vector2.zero, null, UIGenerateType.STACKING, UIGenerateSortType.TOP) as ReSummonUI;
        reSummonUI.SpawnSummonItem(summonCount);
    }
}
