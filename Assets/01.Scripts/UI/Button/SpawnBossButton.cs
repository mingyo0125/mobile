using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossButton : UI_Button
{
    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        WaveManager.Instance.ResetWave();

        WaveManager.Instance.SpawnBossWarningPanel();
        
        transform.parent.gameObject.SetActive(false);
    }
}
