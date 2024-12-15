using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRushClearButton : UI_Button
{
    [SerializeField]
    private bool isClear;
    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        Signalhub.OnEndBossRushEventEvent?.Invoke();

        if(!isClear)
        {
            WaveManager.Instance.EndStage(false);
        }
        else
        {
            CurrencyManager.Instance.GetCurrency(CurrencyType.Jewel, BossRushManager.Instance.GetRewardValue());
        }
    }
}
