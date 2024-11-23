using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItemButton : UI_Button
{
    private SummonItemInfo _item;

    [SerializeField]
    private bool isCloseTopUI;

    public void SetSummonItem(SummonItemInfo summonItem)
    {
        _item = summonItem;
    }

    protected override void ButtonEvent()
    {
        if(InventoryManager.Instance.EquipItem(_item))
        {
            base.ButtonEvent();
        }

        if (isCloseTopUI) { UIManager.Instance.RemoveTopUGUI(); }
    }
}
