using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    protected override void GetItem(Player player)
    {
        MoneyManager.Instance.GetMoney(transform, 10);
        // 돈이 오르도록 하시오
    }
}
