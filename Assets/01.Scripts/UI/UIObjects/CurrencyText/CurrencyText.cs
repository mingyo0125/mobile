using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class CurrencyText : TextMeshProUGUI
{
    protected override void OnEnable()
    {
        base.OnEnable();
        CurrencyManager.Instance.OnCurrencyChangeEvent += UpdateCurrencyText;
    }

    private void UpdateCurrencyText(CurrencyType currencyType, int value)
    {
        if (GetCurrencyType() != currencyType) { return; }

        SetText(value.ToString());
    }

    protected abstract CurrencyType GetCurrencyType();
}
