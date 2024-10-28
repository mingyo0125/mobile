using TMPro;
using UnityEngine;

public class MoneyUI : TextMeshProUGUI
{
    protected override void OnEnable()
    {
        base.OnEnable();
        MoneyManager.Instance.OnSetMoneyEvent += UpdateMoneyUI;
    }

    private void UpdateMoneyUI(int curmoney)
    {
        SetText(curmoney.ToString());
    }
}
