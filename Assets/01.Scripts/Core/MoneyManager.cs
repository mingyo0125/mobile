using System;
using UnityEngine;

public class MoneyManager : MonoSingleTon<MoneyManager>
{
    public event Action<int> OnSetMoneyEvent = null;

    private int money;

    public int GetOwnMoney()
    {
        return money;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SpendMoney(10);
        }
    }

    public void SpendMoney(int value)
    {
        if(money < value)
        {
            // 오류 메시지 무언가
            return;
        }

        money -= value;
        OnSetMoneyEvent?.Invoke(money);

    }

    public void GetMoney(int value)
    {
        money += value;
        OnSetMoneyEvent?.Invoke(money);
    }
}
