using TMPro;
using UnityEngine;

public class MoneyText : CurrencyText
{
    protected override CurrencyType GetCurrencyType()
    {
        return CurrencyType.Money;
    }
}
