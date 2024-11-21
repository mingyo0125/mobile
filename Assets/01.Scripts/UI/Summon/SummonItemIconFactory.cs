using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SummonItemIconFactory : ObjectFactory<InventoryItem_Icon>
{
    private const string InventoryItemIcon = "Inventory_ItemIcon";

    private void Start()
    {
        foreach (var item in GetSummonItems())
        {
            InventoryItem_Icon icon = UIManager.Instance.GenerateUI(InventoryItemIcon, transform) as InventoryItem_Icon;
            icon.SetSummonItem(item);

        }
    }

    protected abstract List<SummonItemInfo> GetSummonItems();
}
