using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonButton : UI_Button
{
    [SerializeField]
    private ReSummonUI _reSummonUI;

    [SerializeField]
    private int summonCount;

    [SerializeField]
    private ItemType _summonItemType;

    [SerializeField]
    private CurrencyType _currenciesType;

    [SerializeField]
    private int cost;

    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        if (!CurrencyManager.Instance.SpendCurrency(_currenciesType, cost))
        {
            return;
        }

        if(_reSummonUI != null)
        {
            _reSummonUI.SpawnSummonItem(summonCount);
            return;
        }

        ReSummonUI reSummonUI = UIManager.Instance.CreateUI($"{_summonItemType}_ReSummonUI", Vector2.zero, null, UIGenerateType.STACKING, UIGenerateSortType.TOP) as ReSummonUI;
        reSummonUI.SpawnSummonItem(summonCount);
    }
}
