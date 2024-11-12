
public class CloseButton : UIButton
{
    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        UIManager.Instance.RemoveTopUGUI();
    }
}
