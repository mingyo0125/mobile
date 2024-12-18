using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[Serializable]
public enum ItemType
{
    Skill,
    Equipment
}

public class InventoryManager : MonoSingleTon<InventoryManager>
{
    public Dictionary<ItemType, Dictionary<string, SummonItemInfo>> EquippedInventory = new ();

    private void Awake()
    {
        foreach(ItemType itemType in Enum.GetValues(typeof(ItemType)))
        {
            EquippedInventory.Add(itemType, new Dictionary<string, SummonItemInfo>());
        }
    }

    public bool EquipItem<T>(T summonItem) where T : SummonItemInfo
    {
        ItemType itemType = summonItem.ItemType;

        if (!SummonItemManager<T>.Instance.EquipSummonItem(summonItem.ItemId)) { return false; }

        summonItem.EquipItem();

        EquippedInventory[itemType].Add(summonItem.ItemId, summonItem);

        Debug.Log($"{itemType}�κ��丮�� {summonItem.ItemId} ����");

        return true;

    }

    public void UnEquipItem<T>(ItemType itemType, string summonItemId) where T : SummonItemInfo
    {
        if (!EquippedInventory[itemType].TryGetValue(summonItemId, out SummonItemInfo summonItem))
        {
            Debug.Log($"{itemType}�κ��丮�� {summonItemId} ��� ���� ���� �Ұ���");
            return;
        }

        SummonItemManager<T>.Instance.UnEquipSummonItem(summonItemId);

        summonItem.UnEquipItem();
        EquippedInventory[itemType].Remove(summonItemId);

        Debug.Log($"{itemType}�κ��丮�� {summonItemId} ���� ����");
    }

}
