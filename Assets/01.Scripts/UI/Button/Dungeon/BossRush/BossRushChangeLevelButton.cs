using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRushChangeLevelButton : UI_Button
{
    [SerializeField]
    private int value;

    private int curLevel;

    public Action<int> OnRequestLevelChange;

    public void SetCurLevel(int level)
    {
        curLevel = level;
    }

    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        OnRequestLevelChange?.Invoke(curLevel + value);
    }
}
