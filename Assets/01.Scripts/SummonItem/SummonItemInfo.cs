using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class SummonItemInfo : ISummonItem, ISavable
{
    [field: SerializeField]
    public string ItemId { get; private set; }

    [field: SerializeField]
    public string ItemName { get; private set; }

    [field: SerializeField]
    public Sprite Icon { get; private set; }

    [field: SerializeField]
    public int ItemLevel { get; private set; }

    [field: SerializeField]
    public ItemType ItemType { get; private set; }

    [field: SerializeField]
    public ItemGradeInfo GradeInfo { get; private set; }

    [HideInInspector]
    [field: SerializeField]
    public int ElementsCount;

    #region Events

    public event Action OnItemUnEquipEvent = null, OnItemGetEvent = null;
    public Action OnItemEquipEvent = null;

    public event Action OnItemLevelUpEvent = null;
    #endregion

    [HideInInspector]
    [field: SerializeField]
    public int UpgradableCount { get; private set; }

    [HideInInspector]
    [field: SerializeField]
    public bool IsLock { get; private set; }

    [HideInInspector]
    [field: SerializeField]
    public bool IsEquipped { get; private set; }

    [HideInInspector]
    [SerializeField]
    public bool CanUpgrade => ElementsCount >= UpgradableCount;

    public string FilePath => GetFilePath();

    public SummonItemInfo(SummonItemInfo summonItemInfo)
    {
        this.ItemId = summonItemInfo.ItemId;
        this.ItemName = summonItemInfo.ItemName;
        this.Icon = summonItemInfo.Icon;
        this.ItemLevel = summonItemInfo.ItemLevel;
        this.ItemType = summonItemInfo.ItemType;
        this.GradeInfo = summonItemInfo.GradeInfo;
        this.ElementsCount = summonItemInfo.ElementsCount;

        OnItemUnEquipEvent = null;
        OnItemGetEvent = null;
        OnItemEquipEvent = null;
        OnItemLevelUpEvent = null;

        ItemLevel = 1;
        UpgradableCount = 2;

        IsLock = true;
    }

    public void AddElementsCount()
    {
        ElementsCount++;
    }

    public virtual bool ItemLevelUp()
    {
        if (!CanUpgrade) { return false; }
        // 부족하다고 알리기 later

        ItemLevelUpEvent();

        return true;
    }

    protected virtual void ItemLevelUpEvent()
    {
        ItemLevel++;

        ElementsCount -= UpgradableCount;

        UpgradableCount += 2;

        Debug.Log($"{ItemName}: {ItemLevel}");

        OnItemLevelUpEvent?.Invoke();
    }

    public virtual void EquipItem()
    {
        OnItemEquipEvent?.Invoke();

        IsEquipped = true;
    }

    public virtual void UnEquipItem()
    {
        IsEquipped = false;

        OnItemUnEquipEvent?.Invoke();
    }

    public virtual void GetItem()
    {
        if (IsLock)
        {
            IsLock = false;
        }

        OnItemGetEvent?.Invoke();
    }

    public float GetSummonProbability()
    {
        float baseProbability = (int)GradeInfo.ItemGradeType;

        return baseProbability;
    }

    protected abstract string GetFilePath();
}
