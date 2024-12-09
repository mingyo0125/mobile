using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SummonItemIconFactory : ObjectFactory<InventoryItem_Icon>
{
    private const string InventoryItemIcon = "Inventory_ItemIcon";

    private Dictionary<string, InventoryItem_Icon> _inventoryItems = new Dictionary<string, InventoryItem_Icon>();

    private void Start()
    {
        List<SummonItemInfo> summonItems = GetSummonItems();
        for (int i = 0; i < summonItems.Count; i++)
        {
            SummonItemInfo item = summonItems[i];
            InventoryItem_Icon icon = UIManager.Instance.CreateUI(InventoryItemIcon, Vector2.zero, transform) as InventoryItem_Icon;
            icon.SetSummonItem(item);
            icon.SetSiblingIndex(i);
            _inventoryItems.Add(item.ItemId, icon);
        }
    }

    public InventoryItem_Icon GetInventoryItemIcon(SummonItemInfo summonItemInfo)
    {
        return _inventoryItems[summonItemInfo.ItemId];
    }

    protected abstract List<SummonItemInfo> GetSummonItems();
}
