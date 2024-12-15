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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            GetCurrency(currencyType, 10);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SpendCurrency(currencyType, 10);
        }
    }

    public bool SpendCurrency(CurrencyType currencyType, int value)
    {
        if (currencys[currencyType] < value)
        {
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
