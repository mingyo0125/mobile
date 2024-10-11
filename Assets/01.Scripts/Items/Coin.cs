using UnityEngine;

public class Coin : Item
{
    int coinValue;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(coinValue);
        return;
    }

    protected override void GetItem(Player player)
    {
        // ���߿� �������ڸ��� UI ������ �� ���ư���
        MoneyManager.Instance.GetMoney(transform, coinValue);
    }

    public void SetCoinValue(int value)
    {
        coinValue = value;
    }
}
