using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Skill,
    
}


public class InventoryManager : MonoSingleTon<InventoryManager>
{
    private Dictionary<ItemType, Dictionary<string, ISummonItem>> _itemInventory = new ();

    private void Awake()
    {
        foreach(ItemType itemType in Enum.GetValues(typeof(ItemType)))
        {
            _itemInventory.Add(itemType, new Dictionary<string, ISummonItem>());
        }
    }

    public void EquipItem(ItemType itemType, SummonItemInfo summonItem)
    {
        _itemInventory[itemType].Add(summonItem.ItemId, summonItem);
        
        Debug.Log($"{itemType}인벤토리에 {summonItem.ItemId} 장착");
    }

    public void UnEquipItem(ItemType itemType, string summonItemName)
    {
        if (!_itemInventory[itemType].ContainsKey(summonItemName))
        {
            Debug.Log($"{itemType}인벤토리에 {summonItemName} 없어서 장착 해제 불가능");
            return;
        }

        _itemInventory[itemType].Remove(summonItemName);
        Debug.Log($"{itemType}인벤토리에 {summonItemName} 장착 해제");
    }
}
