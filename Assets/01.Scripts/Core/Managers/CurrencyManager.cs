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

    public event Action<int> OnSetMoneyEvent = null;

    private int money;

    private int jewel;

    public int GetOwnCurrency(CurrencyType currencyType)
    {
        return currencys[currencyType];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //SpendMoney(10);
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
        OnSetMoneyEvent?.Invoke(currencys[currencyType]);
        return true;

    }

    public void GetCurrency(CurrencyType currencyType, int value)
    {
        currencys[currencyType] += value;
        OnSetMoneyEvent?.Invoke(currencys[currencyType]);
    }
}
