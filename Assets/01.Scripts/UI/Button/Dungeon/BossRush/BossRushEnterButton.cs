using System;

public class BossRushEnterButton : UI_Button
{
    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        Signalhub.OnEnterBossRushEvent?.Invoke();
    }


}
