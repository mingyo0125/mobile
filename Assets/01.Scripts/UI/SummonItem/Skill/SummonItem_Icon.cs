using TMPro;
using Unity.VisualScripting;
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
    protected UnEquipItemButton _unEquipItemButton { get; private set; }
    public SummonItemInfo ItemInfo { get; set; }

    private const string Skill_InfoName = "Skill_Info";

    public virtual void SetSummonItem(SummonItemInfo summonItem)
    {
        ItemInfo = summonItem;
        _unEquipItemButton.SetSummonItem(ItemInfo);
        IsUsingButton = true;

        UpdateLevelText();
        UpdateBGColor();
        Init();
    }

    public void UpdateLevelText()
    {
        _levelText.SetText($"Lv.{ItemInfo.ItemLevel}");
    }

    public void UpdateBGColor()
    {
        _bgImage.color = ItemInfo.GradeInfo.ColorByGrade;
    }

    protected virtual void Init()
    {
        _icon.sprite = ItemInfo.Icon;
        ItemInfo.OnItemLevelUpEvent += UpdateLevelText;
    }

    protected override void ButtonEvent()
    {
        base.ButtonEvent();

        SpawnItemInfoUI();
    }

    private void SpawnItemInfoUI()
    {
        switch (ItemInfo.ItemType)
        {
            case ItemType.Skill:
                Skill_InfoUI itemInfoUI = UIManager.Instance.GenerateUI(Skill_InfoName,
                                                                        null,
                                                                        UIGenerateType.STACKING,
                                                                        UIGenerateSortType.TOP) as Skill_InfoUI;
                itemInfoUI.SetSkillInfo(ItemInfo as SkillInfo);
                break;

            default:
                break;
        }
    }
}
