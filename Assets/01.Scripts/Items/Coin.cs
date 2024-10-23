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
        return;
    }

    public override void Initialize()
    {
        MoneyManager.Instance.GetMoney(transform, coinValue);
        PoolManager.Instance.DestroyObject(this);
    }

    public void SetCoinValue(int value)
    {
        coinValue = value;
    }
}
