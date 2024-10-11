public class Coin : Item
{
    protected override void GetItem(Player player)
    {
        // 이거 UI 위치로 해야됨
        MoneyManager.Instance.GetMoney(transform, 10);
    }
}
