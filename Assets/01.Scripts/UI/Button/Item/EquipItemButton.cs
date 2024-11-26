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
        if(InventoryManager.Instance.EquipItem(ItemInfo))
        {
            base.ButtonEvent();
        }

        if (isCloseTopUI) { UIManager.Instance.RemoveTopUGUI(); }
    }
}
