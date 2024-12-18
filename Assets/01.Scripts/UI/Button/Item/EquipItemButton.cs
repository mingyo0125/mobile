using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItemButton : UI_Button, ISummonItemUI
{
    [SerializeField]
    private bool isCloseTopUI;


    public SummonItemInfo ItemInfo { get; set; }

    public void SetSummonItem(SummonItemInfo summonItem)
    {
        ItemInfo = summonItem;
    }

    protected override void ButtonEvent()
    {
        bool isEquipped = false;

        switch (ItemInfo.ItemType)
        {
            case ItemType.Skill:
                isEquipped = InventoryManager.Instance.EquipItem(ItemInfo as SkillInfo);
                break;

            case ItemType.Equipment:
                isEquipped = InventoryManager.Instance.EquipItem(ItemInfo as EquipmentInfo);
                break;

            default:
                Debug.LogWarning($"Unhandled ItemType: {ItemInfo.ItemType}");
                break;
        }

        if (isEquipped)
        {
            base.ButtonEvent();
        }

        if (isCloseTopUI)
        {
            UIManager.Instance.RemoveTopUGUI();
        }
    }
}
