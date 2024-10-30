using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Coin : Item
{
    int coinValue;

    protected override void GetItem(Player player)
    {
        MoneyManager.Instance.GetMoney(coinValue);
    }

    public void SetCoinValue(int value)
    {
        coinValue = value;
    }
}
