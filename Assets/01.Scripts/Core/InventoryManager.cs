using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public enum ItemType
{
    Skill,
}


public class InventoryManager : MonoSingleTon<InventoryManager>
{
    private Dictionary<ItemType, Dictionary<string, SummonItemInfo>> _equippedInventory = new ();

    private void Awake()
    {
        foreach(ItemType itemType in Enum.GetValues(typeof(ItemType)))
        {
            _equippedInventory.Add(itemType, new Dictionary<string, SummonItemInfo>());
        }
    }

    public bool EquipItem(SummonItemInfo summonItem)
    {
        ItemType itemType = summonItem.ItemType;

        if (!summonItem.EquipItem()) { return false; }

        summonItem.OnItemEquipEvent?.Invoke();

        _equippedInventory[itemType].Add(summonItem.ItemId, summonItem);

        Debug.Log($"{itemType}인벤토리에 {summonItem.ItemId} 장착");

        return true;

    }

    public void UnEquipItem(ItemType itemType, string summonItemName)
    {
        if (!_equippedInventory[itemType].TryGetValue(summonItemName, out SummonItemInfo summonItem))
        {
            Debug.Log($"{itemType}인벤토리에 {summonItemName} 없어서 장착 해제 불가능");
            return;
        }

        summonItem.UnEquipItem();
        _equippedInventory[itemType].Remove(summonItemName);

        Debug.Log($"{itemType}인벤토리에 {summonItemName} 장착 해제");
    }

}
