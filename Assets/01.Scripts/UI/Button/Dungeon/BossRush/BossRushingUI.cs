using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRushingUI : UI_Component
{
    private void Start()
    {
        Signalhub.OnEndBossRushEventEvent += () => UIManager.Instance.RemoveTopUGUI();

        GameManager.Instance.GetPlayer().OnDieEvent += _ => Signalhub.OnEndBossRushEventEvent();
    }
}
