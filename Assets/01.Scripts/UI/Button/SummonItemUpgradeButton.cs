
public class SummonItemUpgradeButton : UI_Button, ISummonItemUI
{
    public SummonItemInfo ItemInfo { get ; set; }

    public void SetSummonItem(SummonItemInfo summonItem)
    {
        ItemInfo = summonItem;
    }

    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        ItemInfo.ItemLevelUp();
    }
}
