using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MoneyManager : MonoSingleTon<MoneyManager>
{
    private event Action<Transform, string, Color> OnMoneyChangedEvent = null;

    private int money;

    private void OnEnable()
    {
        OnMoneyChangedEvent += UIManager.Instance.SpawnHudText;
    }

    public int GetOwnMoney()
    {
        return money;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SpendMoney(transform, -10);
        }
    }

    public void SpendMoney(Transform trm, int value)
    {
        if(money < value)
        {
            // 오류 메시지 무언가
            return;
        }

        money -= value;
        OnMoneyChangedEvent?.Invoke(trm, $"-{value}", Color.red);
    }

    public void GetMoney(Transform trm, int value)
    {
        money += value;
        Debug.Log(trm);
        OnMoneyChangedEvent?.Invoke(trm, $"{value}", Color.yellow);
    }

    private void OnDisable()
    {
        OnMoneyChangedEvent = null;
    }
}
