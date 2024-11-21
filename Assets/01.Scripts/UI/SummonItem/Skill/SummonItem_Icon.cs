using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SummonItem_Icon : UI_Button, ISummonItemUI
{
    [SerializeField]
    private TextMeshProUGUI _levelText;

    [field: SerializeField]
    protected Image _icon { get; private set; }

    [SerializeField]
    private Image _bgImage;

    [field: SerializeField]
    protected EquipItemButton _equipButton { get; private set; }

    [field: SerializeField]
    protected UnEquipItemButton _unEquipItemButton { get; private set; }
    public SummonItemInfo _summonItem { get; set; }

    private const string Skill_InfoName = "Skill_Info";

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
        _levelText.SetText($"Lv.{_summonItem.ItemLevel}");
    }

    public void UpdateBGColor(Color color)
    {
        _bgImage.color = color;
    }

    protected virtual void Init()
    {
        _summonItem.OnItemLevelUpEvent += UpdateLevelText;
    }

    protected override void ButtonEvent()
    {
        base.ButtonEvent();
        Debug.Log("A");
        UIManager.Instance.GenerateUI(Skill_InfoName, null, UIGenerateType.STACKING, UIGenerateSortType.TOP);
    }
}
