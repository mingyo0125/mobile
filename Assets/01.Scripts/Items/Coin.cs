public class Coin : Item
{
    protected override void GetItem(Player player)
    {
        // �̰� UI ��ġ�� �ؾߵ�
        MoneyManager.Instance.GetMoney(transform, 10);
    }
}
