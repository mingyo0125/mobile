using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRushChangeLevelButton : UI_Button
{
    [SerializeField]
    private int value;

    private int curLevel;

    public Func<int, bool> OnRequestLevelChange;

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
