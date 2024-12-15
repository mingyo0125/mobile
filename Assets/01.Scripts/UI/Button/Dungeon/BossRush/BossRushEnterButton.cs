using System;

public class BossRushEnterButton : UI_Button
{
    private int curLevel;

    public void SetCurLevel(int level)
    {
        curLevel = level;
    }

    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        Signalhub.OnEnterBossRushEvent?.Invoke();
    }


}
