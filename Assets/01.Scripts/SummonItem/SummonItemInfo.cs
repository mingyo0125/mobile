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
    public int ItemLevel { get; private set; }

    [field: SerializeField]
    public ItemType ItemType { get; private set; }

    [field: SerializeField]
    public ItemGradeInfo GradeInfo { get; private set; }

    // 나중에 직렬화 지우셈 later
    [field: SerializeField]
    public int ElementsCount { get; private set; }


    #region Events

    public event Action OnItemUnEquipEvent = null, OnItemGetEvent = null;
    public Action OnItemEquipEvent = null;

    public event Action OnItemLevelUpEvent = null;
    #endregion

    public int UpgradableCount { get; private set; }

    private int legendaryCount = 0; // 레전더리 누적 카운트
    private const float legendaryIncrement = 0.01f; // 누적될 때마다 확률 증가량

    public bool IsLock { get; private set; }

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

        UpgradableCount = 2;

        IsLock = true;
    }

    public void AddElementsCount()
    {
        ElementsCount++;
        Debug.Log($"{ItemName}: {ElementsCount}");
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
        if (GradeInfo.ItemGradeType == SummonItemGradeType.Legendary) { legendaryCount = 0; }

        OnItemGetEvent?.Invoke();

        if (IsLock)
        {
            IsLock = false;
        }
    }

    public float GetSummonProbability()
    {
        float baseProbability = (int)GradeInfo.ItemGradeType;

        if (GradeInfo.ItemGradeType == SummonItemGradeType.Legendary) // 레전더리면 legendaryCount에 따라 확률 증가
        {
            baseProbability += legendaryCount * legendaryIncrement;
        }

        return baseProbability;
    }
}
