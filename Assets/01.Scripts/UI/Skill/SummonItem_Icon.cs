using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SummonItem_Icon : UI_Image
{
    [SerializeField]
    private TextMeshProUGUI _levelText;

    [SerializeField]
    private Image _bgImage;

    [SerializeField]
    private EquipItemButton _equipButton;

    private SummonItemInfo _summonItem;

    public void SetSummonItem(SummonItemInfo summonItem)
    {
        _summonItem = summonItem;
        _equipButton.SetSummonItem(_summonItem);

        UpdateLevelText(_summonItem.ItemLevel);
    }

    public void UpdateLevelText(int level)
    {
        _levelText.SetText($"Lv:{level}");
    }

    public void UpdateBGColor(Color color)
    {
        _bgImage.color = color;
    }
}
