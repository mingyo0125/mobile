using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class SummonItem_Icon : UI_Button, ISummonItemUI
{
    [SerializeField]
    private TextMeshProUGUI _levelText;

    [field: SerializeField]
    protected Image _icon { get; private set; }

    [field: SerializeField]
    protected Image _bgImage;

    [field: SerializeField]
    protected UnEquipItemButton _unEquipItemButton { get; private set; }
    public SummonItemInfo ItemInfo { get; set; }

    private const string Skill_InfoName = "Skill_Info";

    private const string Equipment_InfoName = "Equipment_Info";

    public virtual void SetSummonItem(SummonItemInfo summonItem)
    {
        ItemInfo = summonItem;
        IsUsingButton = true;

        UpdateUI();
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
        try
        {
            base.ButtonEvent();

            SpawnItemInfoUI();
        }
        catch { }
    }

    private void SpawnItemInfoUI()
    {
        switch (ItemInfo.ItemType)
        {
            case ItemType.Skill:
                Skill_InfoUI skill_InfoUI = UIManager.Instance.CreateUI(Skill_InfoName,
                                                                      Vector2.zero,
                                                                      null,
                                                                      UIGenerateType.STACKING,
                                                                      UIGenerateSortType.TOP,
                                                                      UIGenerateTweenType.Up) as Skill_InfoUI;
                skill_InfoUI.SetSkillInfo(ItemInfo as SkillInfo);
                break;
            case ItemType.Equipment:
                Equipment_InfoUI equipment_InfoUI = UIManager.Instance.CreateUI(Equipment_InfoName,
                                                                      Vector2.zero,
                                                                      null,
                                                                      UIGenerateType.STACKING,
                                                                      UIGenerateSortType.TOP,
                                                                      UIGenerateTweenType.Up) as Equipment_InfoUI;
                equipment_InfoUI.SetSkillInfo(ItemInfo as EquipmentInfo);
                break;
            default:
                break;
        }
    }

    public override void UpdateUI()
    {
        base.UpdateUI();
        _unEquipItemButton.SetSummonItem(ItemInfo);
        
        
        UpdateLevelText();
        UpdateBGColor();
        Init();
    }
}
