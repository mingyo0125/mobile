using System;
using System.Collections.Generic;
using UnityEngine;

public enum CurrencyType
{
    Money,
    Jewel
}

public class CurrencyManager : MonoSingleTon<CurrencyManager>
{
    private Dictionary<CurrencyType, int> currencys = new Dictionary<CurrencyType, int>();

    public event Action<CurrencyType, int> OnCurrencyChangeEvent = null;

    [SerializeField]
    private CurrencyType currencyType;

    public int GetOwnCurrency(CurrencyType currencyType)
    {
        return currencys[currencyType];
    }

    private void Start()
    {
        foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
        {
            currencys.Add(currencyType, 500);
        }
    }

    public bool SpendCurrency(CurrencyType currencyType, int value)
    {
        if (currencys[currencyType] < value)
        {
            UIManager.Instance.CreateUI("IncompleteCurrencyPanel", Vector2.zero);
            // 오류 메시지 무언가
            return false;
        }

        currencys[currencyType] -= value;
        OnCurrencyChangeEvent?.Invoke(currencyType, currencys[currencyType]);
        return true;

    }

    public void GetCurrency(CurrencyType currencyType, int value)
    {
        currencys[currencyType] += value;

        OnCurrencyChangeEvent?.Invoke(currencyType, currencys[currencyType]);
    }
}
