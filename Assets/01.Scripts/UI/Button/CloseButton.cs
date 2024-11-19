
public class CloseButton : UI_Button
{
    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        UIManager.Instance.RemoveTopUGUI();
    }
}
