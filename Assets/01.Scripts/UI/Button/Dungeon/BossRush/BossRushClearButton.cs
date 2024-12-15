using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRushClearButton : UI_Button
{
    
    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        Signalhub.OnEndBossRushEventEvent?.Invoke();
        UIManager.Instance.RemoveTopUGUI();

        CurrencyManager.Instance.GetCurrency(CurrencyType.Jewel, BossRushManager.Instance.GetRewardCount());
    }
}
