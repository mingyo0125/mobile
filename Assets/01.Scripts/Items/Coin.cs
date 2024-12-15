using UnityEngine;

public class Coin : Item
{
    int coinValue;

    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        _trailRenderer = transform.Find("TrailEffect").GetComponent<TrailRenderer>();
    }

    protected override void GetItem(Player player)
    {
        CurrencyManager.Instance.GetCurrency(CurrencyType.Money, coinValue);
        _trailRenderer.enabled = false;
    }

    public override void Initialize()
    {
        base.Initialize();

        CoroutineUtil.CallWaitForSeconds(0.1f, () => _trailRenderer.enabled = true);
    }

    public void SetCoinValue(int value)
    {
        coinValue = value;
    }
}
