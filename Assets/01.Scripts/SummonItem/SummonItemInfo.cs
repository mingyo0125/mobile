using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SummonItemInfo : ISummonItem
{
    [field: SerializeField]
    public string ItemId { get; private set; }

    [field: SerializeField]
    public string ItemName { get; private set; }

    [field: SerializeField]
    public Sprite Icon { get; private set; }

    [field: SerializeField]
    public float SummonProbability { get; private set; }

    [field: SerializeField]
    public int ItemLevel { get; private set; }

    [field: SerializeField]
    public ItemType ItemType { get; private set; }

    // ���߿� ����ȭ ����� later
    [field: SerializeField]
    public int ElementsCount { get; private set; }

    public int UpgradableCount { get; private set; }

    #region Events

    public event Action OnItemUnEquipEvent = null, OnItemGetEvent = null;
    public Action OnItemEquipEvent = null;

    public event Action OnItemLevelUpEvent = null;
    #endregion

    public SummonItemInfo(SummonItemInfo summonItemInfo)
    {
        this.ItemId = summonItemInfo.ItemId;
        this.ItemName = summonItemInfo.ItemName;
        this.Icon = summonItemInfo.Icon;
        this.SummonProbability = summonItemInfo.SummonProbability;
        this.ItemLevel = summonItemInfo.ItemLevel;
        this.ItemType = summonItemInfo.ItemType;
        this.ElementsCount = summonItemInfo.ElementsCount;

        OnItemUnEquipEvent = null;
        OnItemGetEvent = null;
        OnItemEquipEvent = null;
        OnItemLevelUpEvent = null;

        UpgradableCount = 2;
    }

    public void AddElementsCount()
    {
        ElementsCount++;
    }

    public void ItemLevelUp()
    {
        ItemLevel++;
        UpgradableCount += 2;
        OnItemLevelUpEvent?.Invoke();
    }

    public virtual bool EquipItem()
    {
        return false;
    }

    public virtual void UnEquipItem()
    {
        OnItemUnEquipEvent?.Invoke();
    }

    public virtual void GetItem()
    {
        OnItemGetEvent?.Invoke();
    }
}
