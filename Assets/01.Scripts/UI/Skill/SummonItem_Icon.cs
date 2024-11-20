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

    [field: SerializeField]
    protected UnEquipItemButton _unEquipItemButton { get; private set; }

    protected SummonItemInfo _summonItem { get; private set; }

    public void SetSummonItem(SummonItemInfo summonItem)
    {
        _summonItem = summonItem;
        _equipButton.SetSummonItem(_summonItem);
        _unEquipItemButton.SetSummonItem(_summonItem);

        UpdateLevelText();
        Init();
    }

    public void UpdateLevelText()
    {
        _levelText.SetText($"Lv:{_summonItem.ItemLevel}");
    }

    public void UpdateBGColor(Color color)
    {
        _bgImage.color = color;
    }

    protected virtual void Init()
    {
        _summonItem.OnItemLevelUpEvent += UpdateLevelText;

    }
}
