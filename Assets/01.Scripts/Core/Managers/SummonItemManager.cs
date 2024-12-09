using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SummonItemManager<T> : MonoSingleTon<SummonItemManager<T>> where T : SummonItemInfo
{
    public Dictionary<string, T> Items { get; private set; } = new Dictionary<string, T>();
    public Dictionary<string, int> Inventory { get; private set; } = new Dictionary<string, int>();

    protected virtual void Awake()
    {
        var summonItems = GetSummonItems();

        foreach (T item in summonItems)
        {
            Items.Add(item.ItemId, item);
        }
    }

    public void AddSummonItem(string itemId)
    {
        if (!Items.ContainsKey(itemId)) { return; }

        if (!Inventory.ContainsKey(itemId)) // ó�� ȹ�� ������
        {
            Inventory.Add(itemId, 0);
        }

        // ������ �ִ� ������ ���Ѵ�.
        Items[itemId].AddElementsCount();
    }

    public virtual bool EquipSummonItem(string itemId)
    {
        if (!Inventory.ContainsKey(itemId))
        {
            Debug.LogError($"Player doesn't have {itemId} item");
            return false;
        }

        if (!Items.TryGetValue(itemId, out T item)) { return false; }

        
        return false;
    }

    public virtual void UnEquipSummonItem(string itemId)
    {
        if (!Items.TryGetValue(itemId, out T skill)) { return; }
    }

    public T GetSummonItemInfo(string id)
    {
        if (!Items.TryGetValue(id, out T item_info))
        {
            Debug.LogError($"Player doesn't have {id}");
            return null;
        }

        return item_info;
    }

    protected abstract List<T> GetSummonItems();
}