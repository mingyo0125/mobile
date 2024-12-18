using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SummonItemIconFactory<T> : ObjectFactory<InventoryItem_Icon> where T : SummonItemInfo
{
    private const string InventoryItemIcon = "Inventory_ItemIcon";

    private Dictionary<string, InventoryItem_Icon> _inventoryItems = new Dictionary<string, InventoryItem_Icon>();

    private void Start()
    {
        List<T> summonItems = GetSummonItems();
        for (int i = 0; i < summonItems.Count; i++)
        {
            T item = summonItems[i];
            InventoryItem_Icon icon = UIManager.Instance.CreateUI(InventoryItemIcon, Vector2.zero, transform) as InventoryItem_Icon;
            icon.SetSummonItem(item);
            icon.SetSiblingIndex(i);
            _inventoryItems.Add(item.ItemId, icon);
        }

        ((RectTransform)transform).sizeDelta = new Vector2(0, summonItems.Count * 70);
    }

    public InventoryItem_Icon GetInventoryItemIcon(T summonItemInfo)
    {
        return _inventoryItems[summonItemInfo.ItemId];
    }

    protected abstract List<T> GetSummonItems();
}
