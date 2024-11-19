using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SummonItem_Icon : UI_Image
{
    [SerializeField]
    private TextMeshProUGUI _levelText;

    [SerializeField]
    private Image _bgImage;

    [field: SerializeField]
    protected EquipItemButton _equipButton { get; private set; }
    //[SerializeField]
    //private UnEquipButton _unEquipButton;

    protected SummonItemInfo _summonItem { get; private set; }

    public void SetSummonItem(SummonItemInfo summonItem)
    {
        _summonItem = summonItem;
        _equipButton.SetSummonItem(_summonItem);

        UpdateLevelText(_summonItem.ItemLevel);
        Init();
    }

    public void UpdateLevelText(int level)
    {
        _levelText.SetText($"Lv:{level}");
    }

    public void UpdateBGColor(Color color)
    {
        _bgImage.color = color;
    }

    protected virtual void Init()
    {

    }
}
