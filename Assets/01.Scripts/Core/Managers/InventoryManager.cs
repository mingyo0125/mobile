using System;
using System.Collections.Generic;
using UnityEngine;

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

    public bool EquipItem(SummonItemInfo summonItem)
    {
        ItemType itemType = summonItem.ItemType;

        if (!summonItem.EquipItem()) { return false; }

        summonItem.OnItemEquipEvent?.Invoke();

        EquippedInventory[itemType].Add(summonItem.ItemId, summonItem);

        Debug.Log($"{itemType}�κ��丮�� {summonItem.ItemId} ����");

        return true;

    }

    public void UnEquipItem(ItemType itemType, string summonItemName)
    {
        if (!EquippedInventory[itemType].TryGetValue(summonItemName, out SummonItemInfo summonItem))
        {
            Debug.Log($"{itemType}�κ��丮�� {summonItemName} ��� ���� ���� �Ұ���");
            return;
        }

        summonItem.UnEquipItem();
        EquippedInventory[itemType].Remove(summonItemName);

        Debug.Log($"{itemType}�κ��丮�� {summonItemName} ���� ����");
    }

}
