using System;
using UnityEngine;

public class MoneyManager : MonoSingleTon<MoneyManager>
{
    private Transform _moneyUITrm;

    public event Action<Vector2 ,string, Color> OnMoneyChangedEvent = null;
    public event Action<int> OnSetMoneyEvent = null;

    private int money;

    private void Awake()
    {
        _moneyUITrm = FindAnyObjectByType<MoneyUI>().transform;
    }

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
            // ���� �޽��� ����
            return;
        }

        money -= value;
        // �̰Ŵ� ������ ��ġ������ �ϰ�
        OnSetMoneyEvent?.Invoke(money);
        OnMoneyChangedEvent?.Invoke(Camera.main.ScreenToWorldPoint(_moneyUITrm.position), $"-{value}", Color.red);
    }

    public void GetMoney(Transform trm, int value)
    {
        money += value;
        OnSetMoneyEvent?.Invoke(money);
        OnMoneyChangedEvent?.Invoke(Camera.main.ScreenToWorldPoint(_moneyUITrm.position), $"{value}", Color.yellow);
    }

    private void OnDisable()
    {
        OnMoneyChangedEvent = null;
    }
}
