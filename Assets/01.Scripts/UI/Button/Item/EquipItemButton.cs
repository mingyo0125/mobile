using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItemButton : UI_Button
{
    [SerializeField]
    private ItemType _itemType;

    private ISummonItem _item;

    public void SetSummonItem(ISummonItem summonItem)
    {
        _item = summonItem;
    }

    protected override void ButtonEvent()
    {
        InventoryManager.Instance.EquipItem(_itemType, _item);
    }
}
