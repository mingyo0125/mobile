using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class BossRushEnterButton : UI_Button
{
    private int curLevel;

    public Action<int> OnBossRushEnterEvent;

    public void SetCurLevel(int level)
    {
        curLevel = level;
    }

    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        OnBossRushEnterEvent?.Invoke(curLevel);
    }


}
