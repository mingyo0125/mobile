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
        // 나중에 생성되자마자 UI 쪽으로 슝 날아가게
        MoneyManager.Instance.GetMoney(transform, coinValue);
    }

    public void SetCoinValue(int value)
    {
        coinValue = value;
    }
}
