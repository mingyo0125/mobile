using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Coin : Item
{
    int coinValue;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        return;
    }

    protected override void GetItem(Player player)
    {
        return;
    }

    public override void Initialize()
    {
        base.Initialize();

        CoroutineUtil.CallWaitForSeconds(1f, () =>
        {
            // 플레이어의 반대 방향으로
            this.AttractPosition(transform, transform.position, GameManager.Instance.GetPlayerTrm(), 0.7f, 1.5f, () =>
            {
                MoneyManager.Instance.GetMoney(transform, coinValue);
                PoolManager.Instance.DestroyObject(this);
            });
        });
    }

    public void SetCoinValue(int value)
    {
        coinValue = value;
    }
}
